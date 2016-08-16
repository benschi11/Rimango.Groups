using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Rimango.Groups
{
    public class Migrations : DataMigrationImpl
    {

        public int Create() {

            SchemaBuilder.CreateTable("PersonGroupRecord",
                table => table
                    .ContentPartRecord()
                    .Column<int>("Group_Id")
                    .Column<int>("Person_Id")
                    .Column<string>("Function")
                    .Column<bool>("DisplayNameOnly")
                    .Column<int>("OrderNumber")
                );

            ContentDefinitionManager.AlterPartDefinition(
                "GroupPart", b => b.Attachable());

            return 1;
        }

    }
}