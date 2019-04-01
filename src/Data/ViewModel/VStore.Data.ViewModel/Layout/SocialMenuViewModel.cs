using Abp.Application.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStore.Data.ViewModel.Layout
{
    public class SocialMenuViewModel
    {
        public IReadOnlyList<UserMenu> SocialMenu { get; set; }
    }
}
