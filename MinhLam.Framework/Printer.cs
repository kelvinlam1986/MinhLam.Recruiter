namespace MinhLam.Framework
{
    public class Printer
    {
        public static string CreateScriptForPrint(string zoneName)
        {
            string str =
       "<SCRIPT language='javascript'>\n";
            str += " function openWindow" +
            zoneName + "(obj,h,w)\n";
            str += "{\n";

            str += " var newWindow;";

            str += " if(screen.width){\n";
            str += " var winl = (screen.width-w)/2;\n";
            str += " var wint = (screen.height-h)/2;\n";
            str += " }else{winl = 0;wint =0;}\n";
            str += " if (winl < 0) winl = 0;\n";
            str += " if (wint < 0) wint = 0;\n";

            str += " var props = 'top='+wint+'," +
            "left='+winl+',scrollBars=yes," +
            "resizable=yes,toolbar=no," +
            "menubar=no,location=no," +
            "directories=no,width='+w+'" +
            ",height='+h;\n";

            str += " newWindow = window.open(''" +
            ", 'Add_from_Src_to_Dest', props);\n";

            str += " newWindow.document.writeln('<html>')\n";
            str += " newWindow.document.writeln('<head>')\n";
            str += " newWindow.document.writeln('<Title>Print')\n";
            str += " newWindow.document.writeln('</Title>')\n";
            str += " newWindow.document.writeln('<link href=\"/recruiters/css/style.css\" rel=\"stylesheet\"/>')\n";
            str += " newWindow.document.writeln('<link href=\"/recruiters/css/newstyle.css\" rel=\"stylesheet\"/>')\n";
            str += " newWindow.document.writeln('</head>')\n";
            str += " newWindow.document.writeln('<body topmargin=\"0\" leftmargin=\"0\" marginheight=\"0\" marginwidth=\"0\">');\n";
            str += " newWindow.document.writeln('<form method=\"\" name =\"frm\">')\n";
            str += " newWindow.document.writeln('<table onclick=\"javascript:return false;\" border=0 width=100%><tr><td>');\n";
            str += " var strText = document.getElementById(obj).innerHTML;\n";

            str += " newWindow.document.writeln(strText);\n";
            str += " newWindow.document.writeln('</td></tr></table>');\n";
            str += " var strButton = \"<div align=right>" +
            "<input type=\\\"button\\\" name='btnPrint' " +
            "id='btnPrint' class='Button' value='Print'" +
            "  Onclick=\\\"document.getElementById('" +
            "btnPrint').style.display='none';window.print();" +
            "document.getElementById('btnPrint').style.display=" +
            "'block';\\\"></div>\";\n";
            str += " newWindow.document.writeln(strButton);\n";
            str += " newWindow.document.writeln('</form>');\n";
            str += " newWindow.document.writeln('</body>');\n";
            str += " newWindow.document.writeln('</html>')\n";
            str += " newWindow.document.close();\n";
            str += "}\n";

            str += " String.prototype.replaceAll = " +
            "function(strTarget,strSubString)\n";
            str += " {\n";
            str += " var strReplaceAll = this;\n";
            str += " var intIndexOfMatch = " +
            "strReplaceAll.indexOf( strTarget );\n";
            str += " while (intIndexOfMatch != -1){\n";
            str += "  strReplaceAll = strReplaceAll.replace(" +
            "strTarget, strSubString )\n";
            str += "  intIndexOfMatch = " +
            "strReplaceAll.indexOf( strTarget );}\n";
            str += " return( strReplaceAll );\n";
            str += " }\n";
            str += " \n";

            str += "</SCRIPT>\n";
            return str;
        }
    }
}
