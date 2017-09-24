namespace DesktopApp
{
    class DB
    {
        static DBModel.DBModel _model = new DBModel.DBModel();
        public static DBModel.DBModel GetModel()
        {
            return _model;
        }
    }
}
