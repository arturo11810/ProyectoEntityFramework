using RecetarioSocialServices.Services;
using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetarioSocialData;

namespace RecetarioSocialConsola
{
    public class Program
    {
        //public static Receta UsuarioCtrl = new UsuariosCtrl();
        public static RecetarioSocialContext RSC = new RecetarioSocialContext();

        public static UsuariosCtrl UsuarioCtrl = new UsuariosCtrl(RSC);
        public static RecetasCtrl RecetaCtrl = new RecetasCtrl(RSC);
        public static CategoriasCtrl CategoriasCtrl = new CategoriasCtrl(RSC);
        public static PublicacionesCtrl PublicacionCtrl = new PublicacionesCtrl(RSC);
        static void Main(string[] args)
        {
            Console.WriteLine("");

            var TodosUsuarios = UsuarioCtrl.Get();//Como va a traer una lista de tipo usuarios es necesario tambien agregar la referencia del dominio
            
            var Joaquin=UsuarioCtrl.InsertUser("Joaquin11810", "1234", "Joaquin de Jesus", "Cruz", "Bravo", Convert.ToDateTime("2000/09/01"), "Joaquin@gmail.com");
            Categoria categoria1 = CategoriasCtrl.Insert("Complementos");
            var Receta1 = RecetaCtrl.Insert(null, "Gelatina de mazapán", "1 Lata de Leche Condensada LA LECHERA®\n1 Lata de Leche Evaporada CARNATION® CLAVEL® (1 1/2 tazas)\n1 Lata de Media Crema NESTLÉ®\n6 Piezas de Mazapán de cacahuate (28 g c/u)1 / 2 Taza de Agua\n3 Sobres de Grenetina(7 g c / u), hidratada en 1 / 4 taza de agua y disuelta a baño María\n1 Taza de Nuez caramelizada, picada\n1 Taza de Fresas desinfectadas y cortadas a la mitad\nHojas de Menta fresca desinfectadas" , "Licúa la Leche Condensada LA LECHERA® con la Leche Evaporada CARNATION® CLAVEL®, la Media Crema NESTLÉ®, el mazapán y el agua.\nSin dejar de licuar, añade la grenetina previamente disuelta; vierte en un molde previamente engrasado y refrigera hasta que cuaje.\nDesmolda y decora con un poco nuez, fresas y menta.\nPara desmoldar más fácilmente la gelatina, despega las orillas y calienta ligeramente el molde a fuego bajo.\nLa fresa aporta fibra.", "GELATINA DE MAZAPÁN preparada con LECHE CONDENSADA LA LECHERA®.", true, (int)Joaquin.IdUsuario, new List<int>() {(int)categoria1.IdCategoria }, 132, 12);
            var publicacion1 = PublicacionCtrl.Insert(Convert.ToDateTime(("14/02/2022 14:20:12")), "Esta receta es excelente para que hoy le regalen a su pareja, por eso se las vuelvo a compartir", (int)Receta1.IdReceta);
            var publicacion4 = PublicacionCtrl.Insert(Convert.ToDateTime(("25/12/2021 15:28:12")), "Me gustaria compartirles esta receta", (int)Receta1.IdReceta);

            Categoria categoria2 = CategoriasCtrl.Insert("Pasta");
            var Receta2 = RecetaCtrl.Insert(null, "Espagueti con jamón", "1 Envase de Media Crema NESTLÉ®\n1/2 Taza de Mayonesa\n1 Cucharada de Consomé de pollo en polvo\n3 Rodajas de Jamón de pierna gruesas cortadas en cubos\n1 Paquete de Espagueti 200g\n5 Ramitas de Perejil fresco desinfectado y picado finamente\n1/4 Taza de Queso parmesano rallado para decorar", "Mezcla la Media Crema NESTLÉ® con la mayonesa, el consomé, el jamón y el espagueti previamente cocido y escurrido hasta integrar por completo.\nSirve y decora con un poco de perejil y queso parmesano.\nOfrece.\nSi lo deseas, puedes añadir cubos de piña en almíbar a la pasta.\nEl queso aporta calcio a tu dieta.", "ESPAGUETI CON JAMÓN preparado con MEDIA CREMA NESTLÉ®.", true, (int)Joaquin.IdUsuario, new List<int>() { (int)categoria1.IdCategoria, (int)categoria2.IdCategoria }, 18, 4);
            var publicacion2 = PublicacionCtrl.Insert(Convert.ToDateTime(("12/01/2022 11:20:12")), "Excelente receta para preparar", (int)Receta2.IdReceta);


            var Arturo =UsuarioCtrl.InsertUser("Arturo11810", "1234", "José Arturo", "Castillo", "de Alba", Convert.ToDateTime("1999/09/11"), "Arturo@gmail.com");
            Categoria categoria3 = CategoriasCtrl.Insert("Galletas");
            var Receta3 = RecetaCtrl.Insert(null, "Postre de galleta", "3 Tazas Fresa limpias, desinfectadas y rebanadas delgadas\n1 Lata LA LECHERA® en Balance Sin Grasa*\n1 Lata Media Crema NESTLÉ®\n4 Piezas Yema batidas\n1 Cucharadita *Fécula de maíz\n1 Cucharadita Esencia de vainilla\n1 Paquete Soletas (100 g)\n1/2 Taza Almendra fileteadas", "1.-Licúa la Leche Condensada LA LECHERA®, la Media Crema NESTLÉ®, las yemas, la fécula de maíz y la esencia de vainilla.\n2.-Cocina la preparación a fuego medio por 5 minutos. Revuelve constantemente. Retira del fuego y enfría.\n3.-En un molde rectangular, coloca una capa de Soletas, una de fresas y báñalas con la preparación anterior. Continúa así hasta agotar todos los ingredientes. Refrigera por dos horas y media. Decora con las almendras.", "Postre de galleta con LA LECHERA®", true, (int)Arturo.IdUsuario, new List<int>() { (int)categoria1.IdCategoria, (int)categoria3.IdCategoria }, 47, 10);
            var publicacion3 = PublicacionCtrl.Insert(Convert.ToDateTime(("10/02/2022 8:40:12")), "Le comparto una de mis recetas favoritas de preparar", (int)Receta3.IdReceta);

            /*Console.WriteLine("\nPersonas dadas de alta en su plataforma");
            foreach (var Usuario in TodosUsuarios)
            {
                var s = string.Format("{0},\t{1},\t{2},\t{3},\t{4},\t{5:yyyy-MM-dd HH:mm},\t{6}", Usuario.NombreUsuario, Usuario.Contrasena, Usuario.Nombre, Usuario.PrimerApellido, Usuario.SegundoApellido, Usuario.FechaNacimiento, Usuario.Correo);
                Console.WriteLine(s);
            }*/

            /////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nCualquier usuario se puede dar de alta en su sitio (Un usuario con nombre Hoil)");
            var Hoil = UsuarioCtrl.InsertUser("Hoil11810", "1234", "Carlos", "Hoil", "Cantoral", Convert.ToDateTime("2000/01/13"), "Hoil@gmail.com");


            TodosUsuarios = UsuarioCtrl.Get();
            Console.WriteLine("\nAhora este nuevo usuario se ha dado de alta en su plataforma (Hoil)");
            foreach (var Usuario in TodosUsuarios)
            {
                var s = string.Format("{0},\t{1},\t{2},\t{3}", Usuario.NombreUsuario, Usuario.Nombre, Usuario.PrimerApellido, Usuario.SegundoApellido);
                Console.WriteLine(s);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            /*/////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nUna vez dado de alta, este usuario puede modificar su información");
            //var UsuarioModificar = UsuarioCtrl.GetByUserName("Hoil11810");
            Hoil=UsuarioCtrl.Update((int)Hoil.IdUsuario, Hoil.Contrasena, Hoil.Nombre, Hoil.PrimerApellido, Hoil.SegundoApellido, Convert.ToDateTime("2000/01/13"), "NuevoCorreo@gmail.com");

            TodosUsuarios = UsuarioCtrl.Get();
            Console.WriteLine("\nAhora el usuario Hoil a actualizado sus datos (su correo)");
            foreach (var Usuario in TodosUsuarios)
            {
                var s = string.Format("{0},\t{1},\t{2},\t{3},\t{4},\t{5:yyyy-MM-dd HH:mm},\t{6}", Usuario.NombreUsuario, Usuario.Contrasena, Usuario.Nombre, Usuario.PrimerApellido, Usuario.SegundoApellido, Usuario.FechaNacimiento, Usuario.Correo);
                Console.WriteLine(s);
            }*/
            /////////////////////////////////////////////////////////////////////////////////////////
            //var UsuarioBuscar = UsuarioCtrl.GetByUserName("Hoil11810");
            Console.WriteLine("\nCualquier usuario que este dado de alta puede crear recetas\nPor ejemplo, El usuario Hoil creará dos recetas");
            var Hotcakes= RecetaCtrl.Insert(null, "Hot cakes clásicos", "3/4 Taza de Leche Evaporada\n1 Huevo\n2 Cucharadas de Mantequilla fundida\n1 Cucharadita de Esencia de vainilla\n1 Taza de Harina para hot cakes\n2 Cucharadas de Mantequilla\n1 / 2 Taza de Moras azules\n1 / 2 Taza de Fresas desinfectadas y cortadas en cuartos\n6 Hojas de Menta fresca desinfectadas\n1 Envase de Leche Condensada LA LECHERA® Sirve Fácil", "->Mezcla la Leche Evaporada con el huevo, 2 cucharadas de mantequilla fundida, la esencia de vainilla y la harina para hot cakes.\n->Calienta una sartén, agrega un poco de mantequilla y con ayuda de un cucharón vierte un poco de la mezcla para formar los hot cakes; cocina por ambos lados y repite el procedimiento con el resto de la preparación.\n->Sirve los hot cakes, decora con moras azules, fresas, las hojas de menta y con un poco de Leche Condensada LA LECHERA® Sirve Fácil. Ofrece.\n->Puedes agregar alguna semilla como nuez, almendra o cacahuates a la mezcla de los hot cakes o bien fruta como moras, fresas o plátano para incrementar su sabor.\n->La mantequilla aporta vitamina E.", "HOT CAKES CLÁSICOS preparados con LECHE CONDENSADA LA LECHERA® SIRVE FÁCIL.", true, (int)Hoil.IdUsuario, new List<int>() { }, 25, 6);
            var lasanaManzana = RecetaCtrl.Insert(null, "Lasaña a la manzana", "150 Gramos Tocino picado\n3 Cucharadas Harina de trigo\n1 Lata Leche Evaporada\n2 Tazas Agua\n1 Pieza Pechuga de pollo cortada en cubitos\n2 Piezas Manzana fuji cortadas en rebanadas delgadas\n1 Cucharadita Consomé de pollo en polvo\n2 Cucharadas Mantequilla\n150 Gramos Queso tipo manchego rallado\n1 Paquete Pasta para lasaña láminas precocidas (150 g)", "->Horno precalentado a 180 °C.Para la salsa calienta la mantequilla y fríe el tocino, agrega la harina y deja que dore.Añade la Leche Evaporada CARNATION CLAVEL®, el agua y el consomé de pollo.Cocina hasta que espese moviendo para evitar que se formen grumos.Reserva.\n->Calienta la mantequilla y fríe el pollo hasta que dore. Para la lasaña vacía un poco de la salsa en un molde rectangular, acomoda una capa de Lasaña precocida, un poco de manzanas y guisado de pollo. Repite esta operación y termina con el Queso Tipo Manchego\n->Tapa la parte superior con papel aluminio y hornea durante 30 minutos a 180°C, destápala y déjala otros 10 minutos.\n->Puedes poner agua con limón sobre la manzana para que no se oxide mientras preparas la salsa o la carne.\n->El tocino se encuentra entre los alimentos bajos en azúcar ya que este alimento no contiene azúcar.", "Deliciosa carne de res con manzana", true, (int)Hoil.IdUsuario, new List<int>() { }, 50, 6);
            //Console.WriteLine("Ambas recetas ya fueron agregadas");

            Console.WriteLine("Ambas recetas ya fueron agregadas, ahora en el perfil del usuario (en este caso Hoil) se pueden ver y administrar sus recetas");
            var Recetas = RecetaCtrl.Get((int)Hoil.IdUsuario,null,null, null, null);
            foreach (var Receta in Recetas)
            {
                var s = string.Format("Titulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine(s);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nSe le pueden añadir categorias a una receta si asi lo desea su creador\nPor ejemplo, el usuario Hoil le agregará dos categorias a su receta 'Lasaña a la manzana'");
            //crear las dos categorias
            Categoria cat1=CategoriasCtrl.Insert("Desayunos");//guarda la categoria agregada
            CategoriasCtrl.Insert("Carne");
            Categoria cat2 = CategoriasCtrl.Get("Carn").First();//para ver si funciona el contains
            Categoria cat3 = CategoriasCtrl.Insert("Cenas");//para ver si funciona el contains
            //var Receta2 = RecetaCtrl.GetByTitle("Lasaña a la manzana");
            lasanaManzana = RecetaCtrl.Update((int)lasanaManzana.IdReceta,lasanaManzana.Imagen, lasanaManzana.Titulo, lasanaManzana.Ingredientes,lasanaManzana.Instrucciones,lasanaManzana.TextoExtra, (bool)lasanaManzana.Estado, (int)Hoil.IdUsuario, new List<int>() { (int)cat1.IdCategoria, (int)cat2.IdCategoria }, lasanaManzana.TiempoPreparacionMinutos, lasanaManzana.Porciones);
            Console.WriteLine("Las categorias fueron agregadas a la receta, ahora si cargamos las recetas del usuario (Hoil) podremos visualizarlas");

            //Hoil = UsuarioCtrl.GetUser((int)Hoil.IdUsuario,null);//podriamos buscar las recetas por usuario desde el ctrl pero lo hare de esta manera
            //var Recetas2 = RecetaCtrl.GetByuser((int)UsuarioBuscar2.IdUsuario);
            Recetas = RecetaCtrl.Get((int)Hoil.IdUsuario, null, null, null, null);
            foreach (var Receta in Recetas)
            {
                var s = string.Format("Titulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("->" + categoria.Nombre);
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            Console.WriteLine("\nCabe destacar que esta propuesta le ofrece a usted como encargada la capacidad de agregar o quitar categorias a su gusto (No a los usuarios)");
            ///////////////////////////////////////////////////////////////////

            Console.WriteLine("\nCualquier usuario puede publicar sus recetas creadas las veces que desee\nPor ejemplo, el usuario Hoil publicara las dos recetas que acaba de crear");
            //var Receta3 = RecetaCtrl.GetByTitle("Lasaña a la manzana");
            var publicacionLasana1= PublicacionCtrl.Insert(DateTime.Now, "Me encanto esta receta y se las comparto", (int)lasanaManzana.IdReceta);
            //var Receta4 = RecetaCtrl.GetByTitle("Hot cakes clásicos");
            var publicacionHotCakes1 = PublicacionCtrl.Insert(DateTime.Now, "Mi desayuno favorito, aqui les se los dejo", (int)Hotcakes.IdReceta);
            Console.WriteLine("Ambas recetas fueron publicadas, ahora veamos las publicaciones del usuario Hoil (sus publicaciones apareceran desde la mas reciente hasta la mas vieja)");

            //var usuarioEncontrado = UsuarioCtrl.GetByUserName("Hoil11810");
            var publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, null, null, null, null, null, null);//buscar las publicaciones de un usuario
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);


            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            /////////////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine("\nUna vez que un usuario publica sus recetas, los otros usuarios puede calificarla\nPor ejemplo el usuario Joaquin(4) y Arturo(5) calificarán la receta 'Lasaña a la manzana' creada por Hoil");
            //var usuario1 = UsuarioCtrl.GetByUserName("Joaquin11810");
            //var usuario2 = UsuarioCtrl.GetByUserName("Arturo11810");

            //var Receta5 = RecetaCtrl.GetByTitle("Lasaña a la manzana");
            RecetaCtrl.InsertCalification((int)lasanaManzana.IdReceta, (int)Joaquin.IdUsuario, 4);
            RecetaCtrl.InsertCalification((int)lasanaManzana.IdReceta, (int)Arturo.IdUsuario, 5);
            Console.WriteLine("Las calificaciones ya fueron añadidas, ahora si vemos las recetas del usuario Hoil, estara calificada la de 'Lasaña a la manzana'");

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, null, null, null, null, null, null);//buscar las publicaciones de un usuario
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);


            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            /////////////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine("\nLos usuarios puede comentar las publicaciones de otros usuarios\nPor ejemplo los usuarios Joaquin y Arturo comentarán la publicación 'Hot cakes clásicos' del usuario Hoil");
            //var usuario3 = UsuarioCtrl.GetByUserName("Joaquin11810");
            //var usuario4 = UsuarioCtrl.GetByUserName("Arturo11810");

            //var Receta6 = RecetaCtrl.GetByTitle("Hot cakes clásicos");
            //Obtener las publicaciones de esta receta (como solo es una pues va a traer la unica
            //var publicacion2 = (PublicacionCtrl.GetByIdReceta((int)Receta6.IdReceta)).First();
            PublicacionCtrl.InsertComment(DateTime.Now, "Increible receta, sigue subiendo más contenido", (int)publicacionHotCakes1.IdPublicacion, (int)Joaquin.IdUsuario);
            PublicacionCtrl.InsertComment(DateTime.Now, "De mis recetas favoritas en este sitio", (int)publicacionHotCakes1.IdPublicacion, (int)Arturo.IdUsuario);

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, null, null, null, null, null, null);//buscar las publicaciones de un usuario
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nComentarios:");
                if (publicacion.Comentarios != null)
                {
                    foreach (var comentario in publicacion.Comentarios)//si trae nullo
                    {
                        Console.WriteLine("->" + (UsuarioCtrl.GetUser((int)comentario.IdUsuario, null)).Nombre + ": " + comentario.Descripcion);
                    }
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            

            //////////////////////////////////////////////////////////////////////////////////
            ///

            Console.WriteLine("\nSi en algun momento los usuarios necesitan actualizar alguna de sus recetas, lo pueden hacer sin problema\nPor ejemplo el usuario Hoil le agregara un nuevo ingrediente y una categoria a su receta 'Lasaña a la manzana'");
            //var Receta7 = RecetaCtrl.GetByTitle("Lasaña a la manzana");
            List<int> lst = new List<int>() {(int)cat1.IdCategoria,(int)cat2.IdCategoria,(int)cat3.IdCategoria };
            lasanaManzana= RecetaCtrl.Update((int)lasanaManzana.IdReceta, lasanaManzana.Imagen, lasanaManzana.Titulo, lasanaManzana.Ingredientes + "\nNuevo ingrediente", lasanaManzana.Instrucciones, lasanaManzana.TextoExtra, (bool)lasanaManzana.Estado, lasanaManzana.IdUsuario, lst, lasanaManzana.TiempoPreparacionMinutos, lasanaManzana.Porciones);
            Console.WriteLine("\nAhora si le echamos un vistazo a las recetas del usuario Hoil podremos observar que se encuentra actualizada la receta");


            //Hoil = UsuarioCtrl.GetUser((int)Hoil.IdUsuario, null);//podriamos buscar las recetas por usuario desde el ctrl pero lo hare de esta manera
            //var Recetas2 = RecetaCtrl.GetByuser((int)UsuarioBuscar2.IdUsuario);
            Recetas = RecetaCtrl.Get((int)Hoil.IdUsuario,null,null, null, null);
            foreach (var Receta in Recetas)
            {
                var s = string.Format("Titulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("->" + categoria.Nombre);
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            Console.WriteLine("\nEste cambio se ve automaticamente reflejado en sus publicaciones");

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, null, null, null, null, null, null);//buscar las publicaciones de un usuario
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nComentarios:");
                if (publicacion.Comentarios != null)
                {
                    foreach (var comentario in publicacion.Comentarios)//si trae nullo
                    {
                        Console.WriteLine("->" + (UsuarioCtrl.GetUser((int)comentario.IdUsuario, null)).Nombre + ": " + comentario.Descripcion);
                    }
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");


            ///////////////////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine("\nUn usuario puede Republicar una receta\nPor ejemplo, el usuario Hoil publicara de nuevo la receta de 'Hot cakes clásicos'");
            //var Receta8 = RecetaCtrl.GetByTitle("Lasaña a la manzana");
            var publicacionHotCakes2= PublicacionCtrl.Insert((DateTime.Now).AddSeconds(1), "Les vuelvo a compartir esta receta por que nunca es mal momento para unos HotCakes", (int)Hotcakes.IdReceta);
            Console.WriteLine("La publicación fue añadida, ahora veamos las publicaciones del usuario Hoil");

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, null, null, null, null, null, null);//buscar las publicaciones de un usuario
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nComentarios:");
                if (publicacion.Comentarios != null)
                {
                    foreach (var comentario in publicacion.Comentarios)//si trae nullo
                    {
                        Console.WriteLine("->" + (UsuarioCtrl.GetUser((int)comentario.IdUsuario, null)).Nombre + ": " + comentario.Descripcion);
                    }
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            ///////////////////////////////////////////////////////////////////////////////////
            ///
            lst = new List<int>() {(int)cat1.IdCategoria, (int)cat2.IdCategoria, (int)cat3.IdCategoria };
            Console.WriteLine("\nDe igual manera, un usuario puede ocultar alguna de sus recetas de modo que ningun otro usuario la pueda ver.\nPor ejemplo el usuario Hoil ocultara su receta 'Hot cakes clásicos' de modo que a los demás usuarios unicamente les apareceran las publicaciones de las recetas visibles");
            Hotcakes = RecetaCtrl.Update((int)Hotcakes.IdReceta,Hotcakes.Imagen,Hotcakes.Titulo,Hotcakes.Ingredientes,Hotcakes.Instrucciones,Hotcakes.TextoExtra,false,Hotcakes.IdUsuario,lst,Hotcakes.TiempoPreparacionMinutos,Hotcakes.Porciones);
            Console.WriteLine("La receta ya fue ocultada, ahora veamos las publicaciones del usuario Hoil");

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario,true,null,null, null, null, null);//buscar las publicaciones de un usuario y que tengan un estado determinado
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nComentarios:");
                if (publicacion.Comentarios != null)
                {
                    foreach (var comentario in publicacion.Comentarios)//si trae nullo
                    {
                        Console.WriteLine("->" + (UsuarioCtrl.GetUser((int)comentario.IdUsuario, null)).Nombre + ": " + comentario.Descripcion);
                    }
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            ///////////////////////////////////////////////////////////////////////////////////
            ///
            
            Console.WriteLine("\nDe la misma manera, si un usuario quisiera eliminar alguna de sus publicaciones, lo puede hacer.\nPor ejemplo, el usuario Hoil eliminara su publicacion 'Lasaña a la manzana' (automaticamente los comentarios tambien serán eliminados)");
            PublicacionCtrl.Delete((int)publicacionLasana1.IdPublicacion);

            Console.WriteLine("Ahora veamos las publicaciones del usuario Hoil");

            publicaciones = PublicacionCtrl.Get(null, (int)Hoil.IdUsuario, true, null, null, null, null, null);//buscar las publicaciones de un usuario y que tengan un estado determinado
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nComentarios:");
                if (publicacion.Comentarios != null)
                {
                    foreach (var comentario in publicacion.Comentarios)//si trae nullo
                    {
                        Console.WriteLine("->" + (UsuarioCtrl.GetUser((int)comentario.IdUsuario, null)).Nombre + ": " + comentario.Descripcion);
                    }
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("\n(Nota: Se volvio a hacer visibles la receta 'Hot cakes clásicos' del usuario Hoil para ejemplos posteriores)");
            Hotcakes = RecetaCtrl.Update((int)Hotcakes.IdReceta, Hotcakes.Imagen, Hotcakes.Titulo, Hotcakes.Ingredientes, Hotcakes.Instrucciones, Hotcakes.TextoExtra, true, Hotcakes.IdUsuario, lst, Hotcakes.TiempoPreparacionMinutos, Hotcakes.Porciones);


            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("\nTambien pueden haber usuarios que solo ingresen al sitio a ver recetas pero no quieran crealas");

            //Puede ver todas las publicaciones (Aparecen de las mas recientes a las mas viejas)
            Console.WriteLine("\nSe pueden ver todas las publicaciones del sitio (de la mas reciente a la mas vieja)");
            publicaciones=PublicacionCtrl.Get(null,null,null,null,null,null, null, null);

            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: "+usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            //////////////////////////////////////////////////////////////////////////////////////


            //Puede buscar publicaciones de recetas ya sea por su titulo de receta, categorias, dia, rango de fechas, de la calificacion mas alta
            Console.WriteLine("\nSe pueden filtrar publicaciones por el titulo de la receta (por ejemplo las que tengan la palabra galleta en su titulo)");
            publicaciones = PublicacionCtrl.Get(null, null, null, null, null, "galleta", null, null);
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: " + usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nSe pueden filtrar las publicaciones en un rango de fechas determinado, por ejemplo las del mes de febrero");
            publicaciones = PublicacionCtrl.Get(null, null,null, Convert.ToDateTime("01/02/2022"), Convert.ToDateTime("28/02/2022"), null, null, null);
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: " + usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nTambien se podrian combinar las filtraciones, por ejemplo las publicaciones del mes de febrero y que su titulo contenga la palabra cake");
            publicaciones = PublicacionCtrl.Get(null, null, null, Convert.ToDateTime("01/02/2022"), Convert.ToDateTime("28/02/2022"), "cake", null, null);
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: " + usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nPor ultimo tambien se pueden buscar las publicaciones con un maximo de tiempo de preparacion (por ejemplo las que se preparan en 40 minutos o menos)");
            publicaciones = PublicacionCtrl.Get(null, null, null, null, null,null,40,null);//por tiempo maximo de preparacion
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                //Console.WriteLine("\nCalificacion: " + Receta.Calificacion);
                Console.WriteLine("\nTiempo de preparación en minutos: " + Receta.TiempoPreparacionMinutos);
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: " + usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nTambien se pueden buscar las publicaciones de recetas por porciones (por ejemplo recetas de 6 porciones)");
            publicaciones = PublicacionCtrl.Get(null, null, null, null, null, null, null,6);//pnumero minimo de porciones
            foreach (var publicacion in publicaciones)
            {

                Console.WriteLine("-----------------------------------------------------------------------------------");

                var Receta = publicacion.Receta;
                Console.WriteLine("Fecha: " + publicacion.FechaHoraPublicacion + "\nDescripcion: " + publicacion.Descripcion);
                var s = string.Format("\nTitulo: {0}\n", Receta.Titulo);
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("-" + categoria.Nombre);
                }
                var usuario = UsuarioCtrl.GetUser((int)Receta.IdUsuario, null);
                Console.WriteLine("\nPublicado por: " + usuario.Nombre);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");*/
            /*Console.WriteLine("Las recetas que tienen la categoria de 'Complementos'");
            var r=RecetaCtrl.Get2( null, null, null, null, null, new List<int>() { (int)categoria1.IdCategoria,(int)cat1.IdCategoria });
            foreach (var Receta in r)
            {
                var s = string.Format("Titulo: {0}\n{1}\n\nIngredientes\n{2}\n\nInstrucciones\n{3}\n\nTiempo de preparación en minutos: {4}\n\nPorciones: {5}\n\nEstado: {6}", Receta.Titulo, Receta.TextoExtra, Receta.Ingredientes, Receta.Instrucciones, Receta.TiempoPreparacionMinutos, Receta.Porciones, Receta.EstadoReceta);
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine(s);
                Console.WriteLine("\nCategorias:");
                foreach (var categoria in Receta.Categorias)
                {
                    Console.WriteLine("->" + categoria.Nombre);
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");*/

            Console.WriteLine("\n#");
            Console.ReadKey();
        }

    }
}
