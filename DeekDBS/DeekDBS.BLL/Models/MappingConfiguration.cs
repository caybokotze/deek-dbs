using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DeekDBS.BLL.Models
{
    class MappingConfiguration
    {
        public int Id { get; set; }
        public string SerialzedMappings { get; set; }
    }

    class SerializedMappingStore
    {
        DataTable dt = new DataTable();
        void Configure()
        {
            dt.Rows.Add();
        }
        public int OrderId { get; set; }
        public string PrimaryMappings { get; set; }
        public string SecondaryMapping { get; set; }
        public string Operative { get; set; }
        public string Evaluation { get; set; }
    }
}
