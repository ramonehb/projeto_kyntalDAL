namespace Kyntal
{
    //CLASSE ESTATICA ( static ) não precisa ser instanciada
    public static class Sessao
    {
        public static int IDUsuarioLogado { get; set; }

        public static string NomeUsuarioLogado { get; set; }

        public static int IDTipoUsuario { get; set; }
    }
}
