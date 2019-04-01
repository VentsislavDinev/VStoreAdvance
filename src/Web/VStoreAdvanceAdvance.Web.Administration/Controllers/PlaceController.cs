////Copyright 2012 The VAgency and contributors. http://VAgency.com/
////Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
////You may obtain a copy of the License at
////http://www.apache.org/licenses/LICENSE-2.0
////Unless required by applicable law or agreed to in writing, software distributed under the
////License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
////See the License for the specific language governing permissions and limitations under the License.
//using System;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web.Helpers;
//using System.Web.Mvc;
//using VAgency.Data.ViewModels.Company;
//using System.Web.Mvc.Expressions;
//using HostingStore.Web.Controllers;

//namespace HostingStore.Web.Areas.Administration.Controllers
//{
//    public class PlaceController : BaseController
//    {
//        private const string imagePath = "/Files/uploads";
//        private const int smallImageResizeWidth = 60;
//        private const int smallImageResizeHeight = 60;
//        private const int mediumImageResizeWidth = 60;
//        private const int mediumImageResizeHeight = 100;

//        private string saveMediumImageLocation;

//        private ISpaceConfig _space;
//        private ISpaceEmptyConfig _spaceEmptyConfig;
//        private ICompanySerivice _seo;
//        private IBrowserConfig _populator;

//        private const int pageNumber = 10;

//        public int Id { get; set; }

//        public ISpaceConfig Space { get => _space; set => _space = value; }

//        public ISpaceEmptyConfig SpaceEmptyConfig { get => _spaceEmptyConfig; set => _spaceEmptyConfig = value; }

//        public ICompanySerivice Seo { get => _seo; set => _seo = value; }

//        public IBrowserConfig Populator { get => _populator; set => _populator = value; }

//        public PlaceController(ISpaceConfig space, ISpaceEmptyConfig spaceEmptyConfig, 
//            ICompanySerivice seo, IBrowserConfig populator, IUserSystemData data) : base(data)
//        {
//            Space = space ?? throw new ArgumentNullException(nameof(space));
//            SpaceEmptyConfig = spaceEmptyConfig ?? throw new ArgumentNullException(nameof(spaceEmptyConfig));
//            Seo = seo ?? throw new ArgumentNullException(nameof(seo));
//            Populator = populator ?? throw new ArgumentNullException(nameof(populator));
//        }

//        [HttpGet]

//        // GET: Place/Place
//        public ActionResult Index(int id = 1)
//        {
//            if (this.Space.Space.GetAll().Any())
//            {
//                var page = id;
//                var allItemCounts = this.Space.Space.GetAll().Count();
//                var totalPages = (int)Math.Ceiling(allItemCounts / (decimal)pageNumber);
//                var itemToSkip = (page - 1) * pageNumber;
//                var space = this.Space.Space.GetAll()
//                    .Where(x => x.Author.UserName == this.UserProfile.UserName)
//                    .Select(x => new SpaceViewModel
//                    {
//                        Id = x.Id,
//                        Address = x.Adress,
//                        City = x.City,
//                        Name = x.Name,
//                        AuthorId = x.AuthorId,
//                        CreatedOn = x.CreatedOn,
//                    });

//                var spaceList = new SpaceListViewModel
//                {
//                    SpaceList = space,
//                    TotalPages = totalPages,
//                    CurrentPage = page,
//                };

//                return View(spaceList);
//            }

//            if (!this.SpaceEmptyConfig.SpaceCons.GetAll().Any() && !this.SpaceEmptyConfig.SpaceDescription.All().Any())
//            {
//                return View("EmptySpace");
//            }

//            var getSpaceCons = this.SpaceEmptyConfig.SpaceCons.GetAll()

//                .Select(x => new PlaceListConsViewModel
//                {
//                    Description = x.Description,
//                    Title = x.Title,
//                    Id = x.Id,
//                    FilePath = x.filePath
//                });

//            var getSpaceDesc = this.SpaceEmptyConfig.SpaceDescription.All()
//                .Select(x => new PlaceListDescriptionViewModel
//                {
//                    Description = x.Description,
//                    Title = x.Title,
//                    Id = x.Id,
//                    FilePath = x.FilePath
//                });

//            var viewModel = new PlaceInfoViewModel
//            {
//                PlaceCons = getSpaceCons,
//                PlaceDesc = getSpaceDesc
//            };

//            return View("LendingSpace", viewModel);
//        }
        
//        public ActionResult CreateCons()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateCons(PlaceListConsViewModel placeInfoViewModel)
//        {
//            if (ModelState.IsValid && placeInfoViewModel != null)
//            {
//                try
//                {
//                    var file = new WebImage(placeInfoViewModel.Upload.InputStream).Resize(610, 460);

//                    var fileExtention = file.ImageFormat;

//                    //creating filename to avoid file name conflicts.
//                    var fileName = Guid.NewGuid().ToString();

//                    var curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
//                    if (fileExtention == "png" || fileExtention == "jpeg")
//                    {
//                        saveMediumImageLocation = curretnDirectory;

//                        string fileNameWithExtension = fileName + "." + fileExtention;

//                        //saving file in savedImage folder.
//                        var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
//                        file.Save(saveFile, fileExtention);
//                        await SpaceEmptyConfig.SpaceCons.Create(placeInfoViewModel.Title, placeInfoViewModel.Description, DateTime.Now, fileNameWithExtension);
//                    }
//                    return Redirect("/");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeInfoViewModel);
//        }
        
//        [HttpGet]
//        public ActionResult CreateDesc()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateDesc(PlaceListDescriptionViewModel placeList)
//        {
//            if (ModelState.IsValid && placeList != null)
//            {
//                try
//                {
//                    var file = new WebImage(placeList.Upload.InputStream).Resize(610, 460);

//                    var fileExtention = file.ImageFormat;

//                    //creating filename to avoid file name conflicts.
//                    var fileName = Guid.NewGuid().ToString();

//                    var curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
//                    if (fileExtention == "png" || fileExtention == "jpeg")
//                    {
//                        saveMediumImageLocation = curretnDirectory;

//                        string fileNameWithExtension = fileName + "." + fileExtention;

//                        //saving file in savedImage folder.
//                        var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
//                        file.Save(saveFile, fileExtention);
//                        await SpaceEmptyConfig.SpaceCons.Create(placeList.Title, placeList.Description, DateTime.Now, fileNameWithExtension);
//                    }
//                    return Redirect("/");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeList);
//        }

//        [HttpGet]
//        public ActionResult UpdateCons()
//        {
//            return View();
//        }

//        [HttpPut]
//        public async Task<ActionResult> UpdateCons(PlaceListConsViewModel placeInfoViewModel)
//        {
//            if (ModelState.IsValid && placeInfoViewModel != null)
//            {
//                try
//                {
//                    await SpaceEmptyConfig.SpaceCons.Update(placeInfoViewModel.Id);

//                    return Redirect("");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeInfoViewModel);
//        }

//        [HttpGet]
//        public ActionResult UpdateDesc()
//        {
//            return View();
//        }

//        [HttpPut]
//        public async Task<ActionResult> UpdateDesc(PlaceListDescriptionViewModel placeList)
//        {
//            if (ModelState.IsValid && placeList != null)
//            {
//                try
//                {
//                    await this.SpaceEmptyConfig.SpaceDescription.Update(placeList.Id);

//                    return Redirect("");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeList);
//        }

//        [HttpGet]
//        public ActionResult DeleteCons()
//        {
//            return View();
//        }

//        [HttpDelete]
//        public async Task<ActionResult> DeleteCons(PlaceListConsViewModel placeInfoViewModel)
//        {
//            if (ModelState.IsValid && placeInfoViewModel != null)
//            {
//                try
//                {
//                    await SpaceEmptyConfig.SpaceCons.Delete(placeInfoViewModel.Id, DateTime.Now);

//                    return Redirect("");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeInfoViewModel);
//        }

//        [HttpGet]
        
//        public ActionResult DeleteDesc()
//        {
//            return View();
//        }

//        [HttpDelete]
//        public async Task<ActionResult> DeleteDesc(PlaceListDescriptionViewModel placeList)
//        {
//            if (ModelState.IsValid && placeList != null)
//            {
//                try
//                {
//                    await this.SpaceEmptyConfig.SpaceDescription.Delete(placeList.Id, DateTime.Now);

//                    return Redirect("/");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }

//            return View(placeList);
//        }

//        public ActionResult Details(int id, string placeName)
//        {
//            if (this.Space.Space.GetAll().Any())
//            {
//                var spaceById = this.Space.Space.GetAll().Where(x => x.Id == id)
//                    .Select(x => new SpaceViewModel
//                    {
//                        Id = x.Id,
//                        Address = x.Adress,
//                        CreatedOn = x.CreatedOn,
//                        Description = x.Description,
//                        Name = x.Name,
//                    }).SingleOrDefault();
//                return View(spaceById);
//            }

//            return View("SpaceEmpty");
//        }

//        // GET: Place/Space/Create
//        public ActionResult Create()
//        {
//            var addTicketViewModel = new SpaceViewModel
//            {
//                Categories = this.Populator.Populator.GetSpaceCategory()
//            };

//            return View(addTicketViewModel);
//        }

//        // POST: Place/Space/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create(SpaceViewModel collection)
//        {
//            if (ModelState.IsValid && collection != null)
//            {
//                var file = new WebImage(collection.Upload.InputStream).Resize(610, 460);

//                var fileExtention = file.ImageFormat;

//                //creating filename to avoid file name conflicts.
//                var fileName = Guid.NewGuid().ToString();

//                var curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
//                if (fileExtention == "png" || fileExtention == "jpeg")
//                {
//                    saveMediumImageLocation = curretnDirectory;

//                    string fileNameWithExtension = fileName + "." + fileExtention;

//                    //saving file in savedImage folder.
//                    var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
//                    file.Save(saveFile, fileExtention);
//                    await SpaceEmptyConfig.SpaceCons.Create(collection.Name, collection.Description, DateTime.Now, fileNameWithExtension);
//                }
//                return this.RedirectToAction<HomeController>(x => x.Index(1));
//            }
//            return View(collection);
//        }
        
//        // GET: Place/Space/Edit/5
//        public ActionResult Edit(int id)
//        {
//            var getById = this.Space.Space.GetAll().Where(x => x.Id == id)
//                .Select(x => new SpaceViewModel
//                {
//                    Address = x.Adress,
//                    CreatedOn = x.CreatedOn,
//                    Description = x.Description,
//                    Name = x.Name,
//                    AuthorId = x.Author.UserName
//                });
//            return View(getById);
//        }

//        // POST: Place/Space/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, SpaceViewModel collection)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //string fileName = Path.GetFileName(collection.Upload.FileName);
//                    //string _path = Path.Combine(Server.MapPath("/App_Data"), fileName);
//                    //collection.Upload.SaveAs(_path);

//                    //await this._space.Create(this._crypto.Decrypt(collection.Adress, this._crypto.Encrypt(collection.Name), this._crypto.Encrypt(collection.Description), this._crypto.Encrypt(collection.Phone), DateTime.Now, this.UserProfile.Id, collection.Upload, this._crypto.Encrypt(collection.City), this._crypto.Encrypt(collection.Counrty), _path);
//                    //return RedirectToAction("/");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }
//            return View(collection);
//        }
        
//        // GET: Place/Space/Delete/5
//        public ActionResult Delete(int id)
//        {
//            var getById = this.Space.Space.GetAll().Where(x => x.Id == id)
//                .Select(x => new SpaceViewModel
//                {
//                    Address = x.Adress,
//                    CreatedOn = x.CreatedOn,
//                    Description = x.Description,
//                    Name = x.Name,
//                    AuthorId = x.Author.UserName
//                });
//            return PartialView(getById);
//        }

//        // POST: Place/Space/Delete/5
//        [HttpPost]
//        public async Task<ActionResult> Delete(int id, SpaceViewModel collection)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    string fileName = Path.GetFileName(collection.Upload.FileName);
//                    string _path = Path.Combine(Server.MapPath("/App_Data"), fileName);
//                    collection.Upload.SaveAs(_path);

//                    await this.Space.Space.Delete(id, DateTime.Now);
//                    return RedirectToAction("/");
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//            }
//            return View(collection);
//        }

//        public ActionResult SEO()
//        {
//            if (!this.Seo.Seo.All().Any())
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
//            }
//            var seo = this.Seo.Seo.All()
//                .Select(x => new SEOToolViewModel
//                {
//                    AppId = x.AppId,
//                    GOogleAnalytics = x.GoogleAnalytics,
//                    GoogleVerify = x.GoogleVerify,
//                    ImageName = x.ImageName,
//                    Keyword = x.Keywords,
//                    MsValidator = x.MsValidator,
//                    URL = x.URL,
//                    YandexNumber = x.YandexNumber,
//                })
//                .FirstOrDefault();

//            var viewModel = new SpaceViewModel
//            {
//                Seo = seo
//            };

//            return PartialView(viewModel);
//        }

//        public ActionResult SEOCommon()
//        {
//            if (!this.Seo.Seo.All().Any())
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
//            }
//            var seo = this.Seo.Seo.All()
//                .Select(x => new SEOToolViewModel
//                {
//                    AppId = x.AppId,
//                    GOogleAnalytics = x.GoogleAnalytics,
//                    GoogleVerify = x.GoogleVerify,
//                    ImageName = x.ImageName,
//                    Keyword = x.Keywords,
//                    MsValidator = x.MsValidator,
//                    SiteDescription = x.SiteDescription,
//                    SiteName = x.SiteName,
//                    URL = x.URL,
//                    YandexNumber = x.YandexNumber,
//                })
//                .FirstOrDefault();

//            var viewModel = new PlaceInfoViewModel
//            {
//                Seo = seo
//            };

//            return PartialView(viewModel);
//        }
//    }
//}