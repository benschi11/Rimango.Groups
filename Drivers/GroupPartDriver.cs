using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Rimango.Groups.Models;
using Rimango.Groups.Services;
using Rimango.Groups.ViewModels;

namespace Rimango.Groups.Drivers
{
    public class GroupPartDriver : ContentPartDriver<GroupPart>
    {

        private readonly IGroupService _groupService;

        public GroupPartDriver(IGroupService groupService)
        {
            _groupService = groupService;
        }

        protected override string Prefix
        {
            get { return "RimangoGroups"; }
        }


        protected override DriverResult Editor(GroupPart part, dynamic shapeHelper) {

            var vm = new GroupPartEditViewModel {
                AllPersons = _groupService.GetAllPersons(),
                PersonsInGroup = _groupService.GetAllPersonConnnectionsByGroupId(part.ContentItem.Id)
            };



            return ContentShape("Parts_RimangoGroups_Edit",
                    () => shapeHelper.EditorTemplate(TemplateName: "Parts.RimangoGroups.Edit", Model: vm, Prefix: Prefix)
                );
        }

        protected override DriverResult Editor(GroupPart part, IUpdateModel updater, dynamic shapeHelper) {

            var allPersons = _groupService.GetAllPersons();

            // get JSON from Formfield
            var json = HttpContext.Current.Request.Form["group_json"];
            IList<PersonViewModel> o = Json.Decode(json, typeof(IList<PersonViewModel>));
            
            foreach (var viewModel in o) {
                viewModel.Name = allPersons.FirstOrDefault(p => p.Id == viewModel.Id)?.Name;
            }


            var vm = new GroupPartEditViewModel
            {
                AllPersons = allPersons,
                PersonsInGroup = o
            };

            return ContentShape("Parts_RimangoGroups_Edit",
                  () => shapeHelper.EditorTemplate(TemplateName: "Parts.RimangoGroups.Edit", Model: vm, Prefix: Prefix)
              );
        }
    }
}