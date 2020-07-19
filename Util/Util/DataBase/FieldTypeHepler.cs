using System.Data;

namespace Util
{
    /// <summary>
    /// 数据库字段类型转化
    /// </summary>
    public static class FieldTypeHepler
    {
        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public static DbType ToDbType(string datatype)
        {
            DbType res = DbType.String;
            datatype = datatype.ToLower();
            switch (datatype)
            {
                case "int":
                case "number":
                case "integer":
                case "smallint":
                    res = DbType.Int32;
                    break;
                case "tinyint":
                    res = DbType.Byte;
                    break;
                case "numeric":
                case "real":
                case "float":
                    res = DbType.Single;
                    break;
                case "decimal":
                case "number(8,2)":
                    res = DbType.Decimal;
                    break;
                case "char":
                case "varchar":
                case "nvarchar2":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                    res = DbType.String;
                    break;
                case "bit":
                    res = DbType.Boolean;
                    break;
                case "datetime":
                case "date":
                case "smalldatetime":
                    res = DbType.DateTime;
                    break;
                case "money":
                case "smallmoney":
                    res = DbType.Double;
                    break;
            }
            return res;
        }
    }
}
