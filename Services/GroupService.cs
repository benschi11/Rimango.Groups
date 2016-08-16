using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Rimango.Groups.Models;
using Rimango.Groups.ViewModels;

namespace Rimango.Groups.Services
{
    public interface IGroupService : ISingletonDependency {
        IList<PersonViewModel> GetAllPersonConnnectionsByGroupId(int id);
        IList<PersonViewModel> GetAllPersons();
    }

    public class GroupService : IGroupService {
        private IRepository<PersonGroupRecord> _personGroupRepository;
        private IContentManager _contentManager;

        public GroupService(IRepository<PersonGroupRecord> personGroupRepository, IContentManager contentManager) {
            _personGroupRepository = personGroupRepository;
            _contentManager = contentManager;
        }

        public IList<PersonViewModel> GetAllPersonConnnectionsByGroupId(int id) {
            var selectedPersons = _personGroupRepository
                .Fetch(p => p.Group.Id == id)
                .Select(
                    p => new PersonViewModel {
                        Id = p.Person.Id,
                        Name = ((dynamic)p.Person).person.Name.Value,
                        DisplayNameOnly = p.DisplayNameOnly,
                        Function = p.Function,
                        OrderNumber = p.OrderNumber
                    }
                )
                .ToList();

            return selectedPersons;

        }

        public IList<PersonViewModel> GetAllPersons() {
            var allPersons = _contentManager.Query("Person")
                .List()
                .Select(
                    p => new PersonViewModel {
                        Id = p.Id,
                        Name = ((dynamic)p).person.Name.Value
                    }    
                )
                .ToList();

            return allPersons;
        }
    }
}