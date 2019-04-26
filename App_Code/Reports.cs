using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Reports
{
   
    public List<pt.Applicant> Applicant { get;set;}
    public List<pt.PtInfo> PtInfo { get; set; }
    public List<pt.Stage> Stage { get; set; }
    public List<pt.Inventor> Inventor { get; set; }
    public List<pt.Assignment_info> Assignment_info { get; set; }
    public List<pt.Priority_info> Priority_info { get; set; }
}