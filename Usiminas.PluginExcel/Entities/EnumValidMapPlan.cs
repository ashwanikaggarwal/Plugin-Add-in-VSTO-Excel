using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entities
{
    public enum EnumValidMapPlan
    {
        [Description("Sem pendências")]
        SemPendencias,
        [Description("Nesessário acerto de dados na planilha")]
        AcertoPendencias,
        [Description("Part number não localizado no sistema! Favor contatar o vendedor")]
        PendenciasParNumber
    }
}
