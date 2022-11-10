using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public static class Menu
    {
        public static string MostrarPrincipal()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nIngrese un numero de acuerdo a la accion que necesita realizar");
                Console.WriteLine("[1] Solicitar servicio \n[2] Consultar estado de cuenta \n[3] Consultar seguimiento del pedido \n[4] Salir");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }

            }
            return opcion_elegida;
        }
        public static string MostrarConsultaEncomiendas()
        {
            List<string> encomiendas_habilitadas = new List<string>();
            encomiendas_habilitadas.Add("1");
            encomiendas_habilitadas.Add("2");
            encomiendas_habilitadas.Add("3");
            encomiendas_habilitadas.Add("4");
            encomiendas_habilitadas.Add("5");

            string encomiendas = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nIngrese la cantidad de Encomiendas o Correspondencia que desee enviar en su pedido:");
                encomiendas = Console.ReadLine();

                if (String.IsNullOrEmpty(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!encomiendas_habilitadas.Contains(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - Puede enviar hasta 5 encomiendas por Servicio!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return encomiendas;
        }
        public static string MostrarConsutaPeso(int encomiendas)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un numero de acuerdo al peso del encomienda/correspondencia N° {encomiendas + 1}\n------------------------------------");
                Console.WriteLine("[1] Menor o igual a 500gr \n[2] Mayor a 500gr y hasta 10 kg \n[3] Hasta 20 kg \n[4] Hasta 30 kg \n[5] Mayor");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            return opcion_elegida;
        }
        public static string MostrarConsultaDeseaSalir()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\n¿Desea salir?\n------------------------------------");
                Console.WriteLine("[1] Si \n[2] No");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            return opcion_elegida;
        }
        public static void MostrarConsutaSeguimiento()
        {

        }
        public static bool MostrarConsultaUrgencia()
        {
            {
                List<string> opciones_validas = new List<string>();
                opciones_validas.Add("1");
                opciones_validas.Add("2");

                string opcion_elegida = "";
                bool bandera = true;
                while (bandera)
                {
                    Console.WriteLine("------------------------------------\nPor favor responder correctamente: ¿Es urgente el envio de este pedido? Ingrese el número segén corresponda");
                    Console.WriteLine("[1] Si \n[2] No");
                    opcion_elegida = Console.ReadLine();

                    if (String.IsNullOrEmpty(opcion_elegida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else if (!ValidaEntero(opcion_elegida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else if (!opciones_validas.Contains(opcion_elegida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else
                    {
                        bandera = false;
                    }
                }

                bool rsp = false;
                switch (opcion_elegida)
                {
                    case "1":
                        {
                            rsp = true;
                            break;
                        }
                    case "2":
                        {
                            rsp = false;
                            break;
                        }
                }
                return rsp;
            }
        }
        public static string MostrarConsultaSucursales(string accion)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número dependiendo de la sucursal donde desea {accion.ToLower()} su pedido\n------------------------------------");
                Console.WriteLine("[1] VIEDMA\n[2] CORDOBA\n[3] RESISTENCIA\n[4] CABA \n[5] AGENTE OFICIAL EXTERNO");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            string rsp;
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"{accion} en Sucursal de VIEDMA";
                        break;
                    }
                case "2":
                    {
                        rsp = $"{accion} en Sucursal de CORDOBA";
                        break;
                    }
                case "3":
                    {
                        rsp = $"{accion} en Sucursal de RESISTENCIA";
                        break;
                    }
                case "4":
                    {
                        rsp = $"{accion} en Sucursal de CABA";
                        break;
                    }
                case "5":
                    {
                        rsp = $"{accion} en Agente oficial externo";
                        break;
                    }
                default:
                    rsp = "Sin Identificar";
                    break;
            }
            return rsp;
        }


        public static string MostrarConsultaProvincia(string ubicacion)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");
            opciones_validas.Add("6");
            opciones_validas.Add("7");
            opciones_validas.Add("8");
            opciones_validas.Add("9");
            opciones_validas.Add("10");
            opciones_validas.Add("11");
            opciones_validas.Add("12");
            opciones_validas.Add("13");
            opciones_validas.Add("14");
            opciones_validas.Add("15");
            opciones_validas.Add("16");
            opciones_validas.Add("17");
            opciones_validas.Add("18");
            opciones_validas.Add("19");
            opciones_validas.Add("20");
            opciones_validas.Add("21");
            opciones_validas.Add("22");
            opciones_validas.Add("23");
            opciones_validas.Add("24");

            string opcion_elegida = "";
            bool bandera = true;

            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número segun la Provincia de {ubicacion} que corresponda:  ");
                Console.WriteLine("[1] CABA \n[2] BUENOS AIRES \n[3] CORDOBA \n[4] SAN JUAN \n[5] SAN LUIS \n[6] SANTA CRUZ \n[7] CHUBUT \n[8] RIO NEGRO ");
                Console.WriteLine("[9] NEUQUEN \n[10] LA PAMPA \n[11] TIERRA DEL FUEGO \n[12] MENDOZA \n[13] LA RIOJA \n[14] ENTRE RIOS \n[15] SANTA FE \n[16] CORRIENTES ");
                Console.WriteLine("[17] MISIONES \n[18] CHACO \n[19] CATAMARCA \n[20] SANTIAGO DEL ESTERO \n[21] TUCUMAN \n[22] FORMOSA \n[23] SALTA \n[24] JUJUY");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No ingreso ninguna provincia.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida.ToUpper().Trim()))
                {
                    Console.WriteLine("------------------------------------\nERROR - Ingreso una provincia inexistente!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            string rsp = "";
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = "CABA";
                        break;
                    }
                case "2":
                    {
                        rsp = "BUENOS AIRES";
                        break;
                    }
                case "3":
                    {
                        rsp = "CORDOBA";
                        break;
                    }
                case "4":
                    {
                        rsp = "SAN JUAN";
                        break;
                    }
                case "5":
                    {
                        rsp = "SAN LUIS";
                        break;
                    }
                case "6":
                    {
                        rsp = "SANTA CRUZ";
                        break;
                    }
                case "7":
                    {
                        rsp = "CHUBUT";
                        break;
                    }
                case "8":
                    {
                        rsp = "RIO NEGRO";
                        break;
                    }
                case "9":
                    {
                        rsp = "NEUQUEN";
                        break;
                    }
                case "10":
                    {
                        rsp = "LA PAMPA";
                        break;
                    }
                case "11":
                    {
                        rsp = "TIERRA DEL FUEGO";
                        break;
                    }
                case "12":
                    {
                        rsp = "MENDOZA";
                        break;
                    }
                case "13":
                    {
                        rsp = "LA RIOJA";
                        break;
                    }
                case "14":
                    {
                        rsp = "ENTRE RIOS";
                        break;
                    }
                case "15":
                    {
                        rsp = "SANTA FE";
                        break;
                    }
                case "16":
                    {
                        rsp = "CORRIENTES";
                        break;
                    }
                case "17":
                    {
                        rsp = "MISIONES";
                        break;
                    }
                case "18":
                    {
                        rsp = "CHACO";
                        break;
                    }
                case "19":
                    {
                        rsp = "CATAMARCA";
                        break;
                    }
                case "20":
                    {
                        rsp = "SANTIAGO DEL ESTERO";
                        break;
                    }
                case "21":
                    {
                        rsp = "TUCUMAN";
                        break;
                    }
                case "22":
                    {
                        rsp = "FORMOSA";
                        break;
                    }
                case "23":
                    {
                        rsp = "SALTA";
                        break;
                    }
                case "24":
                    {
                        rsp = "JUJUY";
                        break;
                    }
            }
            return rsp;
        }
        
        public static string MostrarConsultaLocalidadXProvincia(string provincia)
        {
            //var localidades = JsonConvert.DeserializeObject<Dictionary<string, string>>("{'CABA': 'CONSTITUCION|MONSERRAT|PUERTO MADERO|RETIRO|SAN TELMO|SAN NICOLAS|RECOLETA|BALVANERA|SAN CRISTOBAL|BARRACAS|BOCA|NUEVA POMPEYA|PARQUE PATRICIOS|ALMAGRO|BOEDO|CABALLITO|FLORES|PARQUE CHACABUCO|VILLA LUGANO|VILLA RIACHUELO|VILLA SOLDATI|LINIERS|MATADEROS|PARQUE AVELLANEDA|FLORESTA|MONTE CASTRO|VELEZ SARSFIELD|VERSALLES|VILLA LURO|VILLA REAL|VILLA DEL PARQUE|VILLA DEVOTO|VILLA GENERAL MITRE|VILLA SANTA RITA|COGHLAN|SAAVEDRA|VILLA PUEYRREDON|VILLA URQUIZA|BELGRANO|COLEGIALES|NUÑEZ|PALERMO|AGRONOMIA|CHACARITA|PARQUE CHAS|PATERNAL|VILLA CRESPO|VILLA ORTUZAR','BUENOS AIRES': 'Alberti|Almirante Brown|Avellaneda|Ayacucho|Azul|Bahía Blanca|Balcarce|Baradero|Arrecifes|Benito Juárez|Berazategui|Berisso|Bolívar|Bragado|Brandsen|Campana|Cañuelas|Capitán Sarmiento|Carlos Casares|Carlos Tejedor|Carmen de Areco|Castelli|Colón|Coronel de Marina Leonardo Rosales|Coronel Dorrego|Coronel Pringles|Chacabuco|Chascomús|Chivilcoy|Daireaux|Dolores|Ensenada|Escobar|Esteban Echeverría|Exaltación de la Cruz|José M. Ezeiza|Florencio Varela|Florentino Ameghino|General Alvarado|General Arenales|General Guido|General Juan Madariaga|General La Madrid|General Las Heras|General Lavalle|General Paz|General Pinto|General Pueyrredón|General Rodríguez|Ciudad Libertador San Martín|General Viamonte|General Villegas|Guaminí|Hipólito Yrigoyen|Hurlingham|Ituzaingó|José C. Paz|Junín|La Costa|La Matanza|Lanús|La Plata|Laprida|Las Flores|Leandro N. Alem|Lincoln|Lobería|Lobos|Lomas de Zamora|Luján|Magdalena|Maipú|Malvinas Argentinas|Mar Chiquita|Marcos Paz|Mercedes|Merlo|Monte|Moreno|Morón|Navarro|Necochea|9 de Julio|Olavarría|Patagones|Pehuajó|Pellegrini|Pergamino|Pila|Pilar|Pinamar|Presidente Perón|Puán|Punta Indio|Quilmes|Ramallo|Rauch|Rivadavia|Rojas|Roque Pérez|Saavedra|Saladillo|Salto|Salliqueló|Andrés de Giles|San Antonio de Areco|San Cayetano|San Fernando|San Isidro|San Nicolás|San Pedro|San Vicente|Suipacha|Tandil|Tapalqué|Tigre|Tordillo|Tornquist|Trenque Lauquen|Tres Arroyos|Tres de Febrero|Tres Lomas|25 de Mayo|Vicente López|Villa Gesell|Villarino|Zárate','CATAMARCA': 'Ambato|Ancasti|Andalgalá|Antofagasta de la Sierra|Belén|Capayán|San Fernando del Valle de Catamarca|El Alto|Fray Mamerto Esquiú|La Paz|Paclín|Pomán|Santa María|Santa Rosa|Tinogasta|Valle Viejo','CORDOBA': 'Calamuchita|Cordoba|Colón|Cruz del Eje|General Roca|General San Martín|Ischilín|Juárez Celman|Marcos Juárez|Minas|Pocho|Presidente Roque Sáenz Peña|Punilla|Río Cuarto|Río Primero|Río Seco|Río Segundo|San Alberto|San Javier|San Justo|Santa María|Sobremonte|Tercero Arriba|Totoral|Tulumba|Unión|Bella Vista','CORRIENTES': 'Berón de Astrada|Corrientes|Concepción|Curuzu Cuatia|Empedrado|Esquina|General Alvear|General Paz|Goya|Itatí|Ituzaingó|Lavalle|Mburucuyá|Mercedes|Monte Caseros|Paso de los Libres|Saladas|San Cosme|San Luis del Palmar|San Martín|San Miguel|San Roque|Santo Tomé|Sauce','CHACO': 'Almirante Brown|Bermejo|Comandante Fernández|Chacabuco|12 de Octubre|2 de Abril|Fray Justo Santa María de Oro|General Belgrano|General Donovan|General Güemes|Independencia|Libertad|Libertador General San Martín|Maipú|Mayor Luis J. Fontana|9 de Julio|O Higgins| Presidencia de la Plaza| 1ro de Mayo|Quitilipi|San Fernando|San Lorenzo|Sargento Cabral|Tapenagá|25 de Mayo','CHUBUT': 'Biedma|Cushamen|Escalante|Florentino Ameghino|Futaleufú|Gaiman|Gastre|Languiñeo|Mártires|Paso de Indios|Rawson|Río Senguer|Sarmiento|Tehuelches|Telsen','ENTRE RIOS': 'Colón|Concordia|Diamante|Federación|Federal|Feliciano|Gualeguay|Gualeguaychú|Islas del Ibicuy|La Paz|Nogoyá|Paraná|San Salvador|Tala|Uruguay|Victoria|Villaguay','FORMOSA': 'Bermejo|Formosa|Laishí|Matacos|Patiño|Pilagás|Pilcomayo|Pirané|Ramón Lista','JUJUY': 'Cochinoca|El Carmen|Dr. Manuel Belgrano|Humahuaca|Ledesma|Palpalá|Rinconada|San Antonio|San Pedro|Santa Bárbara|Santa Catalina|Susques|Tilcara|Tumbaya|Valle Grande|Yaví','LA PAMPA': 'Atreucó|Caleu Caleu|La Pampa|Catriló|Conhelo|Curacó|Chalileo|Chapaleufú|Chical Co|Guatraché|Hucal|Lihuel Calel|Limay Mahuida|Loventué|Maracó|Puelén|Quemú Quemú|Rancul|Realicó|Toay|Trenel|Utracán','LA RIOJA': 'Arauco|La Rioja|Castro Barros|Coronel Felipe Varela|Chamical|Chilecito|Famatina|General Ángel V. Peñaloza|General Belgrano|General Juan F. Quiroga|General Lamadrid|General Ocampo|General San Martín|Vinchina|Independencia|Rosario Vera Peñaloza|San Blas de Los Sauces|Sanagasta','MENDOZA': 'Mendoza|General Alvear|Godoy Cruz|Guaymallén|Junín|La Paz|Las Heras|Lavalle|Luján de Cuyo|Maipú|Malargüe|Rivadavia|San Carlos|San Martín|San Rafael|Santa Rosa|Tunuyán|Tupungato','MISIONES': 'Apóstoles|Cainguás|Candelaria|Misiones|Concepción|Eldorado|General Manuel Belgrano|Guaraní|Iguazú|Leandro N. Alem|Libertador General San Martín|Montecarlo|Oberá|San Ignacio|San Javier|25 de Mayo','NEUQUEN': 'Aluminé|Añelo|Catán Lil|Collón Curá|Confluencia|Chos Malal|Huiliches|Lácar|Loncopué|Los Lagos|Minas|Ñorquín|Pehuenches|Picún Leufú|Picunches|Zapala','RIO NEGRO': 'Adolfo Alsina|Avellaneda|Bariloche|Conesa|El Cuy|General Roca|9 de julio|Ñorquinco|Pichi Mahuida|Pilcaniyeu|San Antonio|Valcheta|25 de Mayo','SALTA': 'Anta|Cachi|Cafayate|Salta|Cerrillos|Chicoana|General Güemes|General José de San Martín|Guachipas|Iruya|La Caldera|La Candelaria|La Poma|La Viña|Los Andes|Metán|Molinos|Orán|Rivadavia|Rosario de la Frontera|Rosario de Lerma|San Carlos|Santa Victoria','SAN JUAN': 'Albardón|Angaco|Calingasta|Caucete|Chimbas|Iglesia|Jáchal|9 de Julio|Pocito|Rawson|Rivadavia|San Martín|Santa Lucía|Sarmiento|Ullum|Valle Fértil|25 de Mayo|Zonda','SAN LUIS': 'Ayacucho|Belgrano|Coronel Pringles|Chacabuco|General Pedernera|Gobernador Dupuy|Junín|Juan Martín de Pueyrredón|Libertador General San Martín','SANTA CRUZ': 'Corpen Aike|Deseado|Güer Aike|Lago Argentino|Lago Buenos Aires|Magallanes|Río Chico','SANTA FE': 'Belgrano|Caseros|Castellanos|Villa Constitución|Garay|General López|General Obligado|Iriondo|La Capital|Las Colonias|9 de Julio|Rosario|San Cristóbal|San Javier|San Jerónimo|San Justo|San Lorenzo|San Martín|Vera','SANTIAGO DEL ESTERO': 'Aguirre|Alberdi|Atamisqui|Avellaneda|Banda|Belgrano|Santiago del Estero|Copo|Choya|Figueroa|General Taboada|Guasayán|Jiménez|Juan F. Ibarra|Loreto|Mitre|Moreno|Ojo de Agua|Pellegrini|Quebrachos|Río Hondo|Rivadavia|Robles|Salavina|San Martín|Sarmiento|Silípica','TUCUMAN': 'Burruyacú|Cruz Alta|Chicligasta|Famaillá|Graneros|Juan Bautista Alberdi|La Cocha|Leales|Lules|Monteros|Río Chico|Simoca|Tafí del Valle|Tafí Viejo|Trancas|Yerba Buena','TIERRA DEL FUEGO': 'Río Grande|Ushuaia'}");
            string localidades_por_provincia = Path.GetFullPath("..\\..\\..\\LocalidadesXProvincia.txt");
            FileInfo FI = new FileInfo(localidades_por_provincia);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(localidades_por_provincia);
            int contador_lineas = 0;
            string opcion_elegida = "";
            string rsp = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var localidades = lineas[contador_lineas].Split('|');
                //contador_lineas++;
                if (localidades[0] == provincia)
                {
                    List<string> opciones_validas = new List<string>();
                    int agrego_nueva_opcion = 0;
                    foreach (string item in localidades)
                    {
                        opciones_validas.Add($"{agrego_nueva_opcion}");
                        agrego_nueva_opcion++;
                    }

                    bool bandera = true;
                    while (bandera)
                    {
                        Console.WriteLine($"------------------------------------\nIngrese la localidad que corresponda: \n------------------------------------");
                        int una_localidad = 1;
                        foreach (var item in localidades)
                        {
                            if (agrego_nueva_opcion != una_localidad)
                            {
                                Console.WriteLine($"[{una_localidad}] {localidades[una_localidad]}");
                                una_localidad++;
                            }
                        }
                        
                        opcion_elegida = Console.ReadLine();
                        if (String.IsNullOrEmpty(opcion_elegida))
                        {
                            Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                            Console.WriteLine("------------------------------------\nIntente nuevamente!");
                        }
                        else if (!ValidaEntero(opcion_elegida))
                        {
                            Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                            Console.WriteLine("------------------------------------\nIntente nuevamente!");
                        }
                        else if (!opciones_validas.Contains(opcion_elegida))
                        {
                            Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                            Console.WriteLine("------------------------------------\nIntente nuevamente!");
                        }
                        else
                        {
                            bandera = false;
                        }
                    }
                    rsp = localidades[int.Parse(opcion_elegida)];
                    break;
                }
                else
                {
                    contador_lineas++;
                }
            }
            SR.Close();
            return rsp;
        }
        
        public static string MostrarConsultaDireccionNacional(string tipo_de_direccion)
        {
            string direccion_origen = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese su dirección de {tipo_de_direccion} de la siguiente forma: 'Calle, Altura, Departamento y Código Postal' ");
                direccion_origen = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(direccion_origen))
                {
                    Console.WriteLine("------------------------------------\nERROR - Deberá aclarar una direccion valida!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return direccion_origen;
        }
        public static string MostrarConsultaRetiroEntrega(string opcion1, string opcion2, string tipo_de_envio)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número según la opción de {tipo_de_envio} que desee:\n------------------------------------");
                Console.WriteLine($"[1] {opcion1} \n[2] {opcion2}");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            string rsp = "";
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"{opcion1}";
                        break;
                    }
                case "2":
                    {
                        rsp = $"{opcion2}";
                        break;
                    }
            }
            return rsp;
        }

        public static string MostrarConsultaInternacional()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string rsp = "";
            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\n¿Desea enviar su encomienda/correspondencia dentro de Argentina?: \n[1] Si \n[2] No");
                opcion_elegida = Console.ReadLine();
                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = "Nacional";
                        break;
                    }
                case "2":
                    {
                        rsp = "Internacional";
                        break;
                    }
            }
            return rsp;
        }
        public static string MostrarConsultaRegionInternacional()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\n¿Hacia que parte del mundo desea enviar su pedido? Ingrese un número segun corresponda: \n------------------------------------");
                Console.WriteLine("[1] A PAISES LIMITROFES\n[2] AMERICA DEL SUR\n[3] AMERICA DEL NORTE\n[4] EUROPA \n[5] ASIA");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            string rsp = "";
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"PAISES LIMITROFES";
                        break;
                    }
                case "2":
                    {
                        rsp = $"AMERICA DEL SUR";
                        break;
                    }
                case "3":
                    {
                        rsp = $"AMERICA DEL NORTE";
                        break;
                    }
                case "4":
                    {
                        rsp = $"EUROPA";
                        break;
                    }
                case "5":
                    {
                        rsp = $"ASIA";
                        break;
                    }
            }
            return rsp;
        }
        public static string MostrarConsultaDireccionInternacional()
        {
            string direccion_destino = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese la dirección de destino: 'Calle, Altura, Departamento, Ciudad y País' ");
                direccion_destino = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(direccion_destino))
                {
                    Console.WriteLine("------------------------------------\nERROR - Deberá aclarar una direccion valida!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return direccion_destino;
        }

        private static bool ValidaEntero(string numero)
        {
            bool rsp = true;
            int entero_validado;

            if (!int.TryParse(numero, out entero_validado))
            {
                rsp = false;
            }
            else if (entero_validado <= 0)
            {
                rsp = false;
            }
            return rsp;
        }

        public static string MostrarResumenPedido(int cantidad_encomiendas, decimal tarifa, string origen, string destino, int numero_pedido)
        {
            Console.WriteLine($"------------------------------------\nRESUMEN DEL PEDIDO N°{numero_pedido}");

            if (cantidad_encomiendas == 1)
            {
                Console.WriteLine($"Encomienda/correspondencia a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa)} \nOrigen: {origen} \nDestino: {destino}");
            }
            else
            {
                Console.WriteLine($"Encomiendas/correspondencias a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa)} \nOrigen: {origen} \nDestino: {destino}");
            }

            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida;
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nPor favor confirmar el pedido");
                Console.WriteLine("[1] Confirmar \n[2] Cancelar");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion. Por favor seleccione una opcion!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return opcion_elegida;
        }
    }
}
