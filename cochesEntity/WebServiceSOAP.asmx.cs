using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using cochesEntity.Controllers;
using System.Xml.Serialization;
using System.IO;

namespace cochesEntity
{
    /// <summary>
    /// Descripción breve de WebServiceSOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceSOAP : System.Web.Services.WebService
    {
        private CochesCutresEntities db = new CochesCutresEntities();

        [WebMethod]
        public List<clientes> Cliente()
        {
        
           var cli = db.clientes.Select(x=>x).Take(2) ;
           
            return cli.ToList();
        }
    }
}
