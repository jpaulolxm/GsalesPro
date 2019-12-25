using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public class Base
    {
        public const string dataBaseManager = "Manager";
        private string _managerConnectionString = "Data Source=Manager";
        private int limit = 50;
        public int countOs = 0;
        public async void execute()
        {
            try
            {
                AppCreateDB();
            }
            catch { }
        }
        private async void AppCreateDB()
        {
            if (!File.Exists(dataBaseManager))
            {
                SQLiteConnection.CreateFile(dataBaseManager);
                await AppCreateTable();
            }
        }
        private async Task<bool> AppCreateTable()
        {
            string[] tables = new string[]
            {
                "CREATE TABLE estados (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(2))",
                "CREATE TABLE cidades (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(255), dbService VARCHAR(255))",
            };

            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            try
            {
                for (int i = 0; i < tables.Count(); i++)
                {
                    SQLiteCommand command = new SQLiteCommand(tables[i], conexao);
                    command.ExecuteNonQuery();
                }
                tablesSeedersEstados();
                tablesSeedersCidades();
            }
            catch { conexao.Close(); }
            conexao.Close();
            return true;
        }

        private void tablesSeedersCidades()
        {
           Dictionary<string,string> cidades = new Dictionary<string, string>
            {
                { "ALMIRANTE TAMANDARE","06294~NETSALES_BASE_ISP" },
                { "ALVORADA","07458~NETSALES_BASE_SUL" },
                { "AMERICANA","05386~NETSALES_BASE_ABC" },
                { "AMPARO","05389~NETSALES_BASE_ABC" },
                { "ANANINDEUA","00178~NETSALES_BASE_SOC" },
                { "ANAPOLIS","18511~NETSALES_BASE_BR" },
                { "APARECIDA","05399~NETSALES_BASE_SOC" },
                { "APARECIDA DE GOIANIA","08895~NETSALES_BASE_ISP" },
                { "APUCARANA","06322~NETSALES_BASE_SUL" },
                { "ARACAJU","02550~NETSALES_BASE_ISP" },
                { "ARACATUBA","05404~NETSALES_BASE_ABC" },
                { "ARACOIABA DA SERRA","05405~NETSALES_BASE_ABC" },
                { "ARAGUARI","03455~NETSALES_BASE_ISP" },
                { "ARAPONGAS","53902~NETSALES_BASE_SUL" },
                { "ARARAQUARA","05409~NETSALES_BASE_ABC" },
                { "ARARAS", "05413~NETSALES_BASE_ABC" },
                { "ARAUCARIA", "06333~NETSALES_BASE_ISP" },
                { "RMACAO DOS BUZIOS", "05116~NETSALES_BASE_ABC" },
                { "ARTUR NOGUEIRA", "05419~NETSALES_BASE_ISP" },
                { "ARUJA", "05420~NETSALES_BASE_SUL" },
                { "ATIBAIA", "05423~NETSALES_BASE_ABC" },
                { "BAGE", "66770~NETSALES_BASE_SUL" },
                { "BALNEARIO CAMBORIU","07052~NETSALES_BASE_ISP" },
                { "BARRA MANSA","05100~NETSALES_BASE_ABC" },
                { "BARRINHA","05442~NETSALES_BASE_ABC" },
                { "BARUERI","05443~NETSALES_BASE_SOC" },
                { "BATATAIS","05448~NETSALES_BASE_SUL" },
                { "BAURU","05449~NETSALES_BASE_ISP" },
                { "BELEM","00194~NETSALES_BASE_SOC" },
                { "BELFORD ROXO","05105~NETSALES_BASE_SOC" },
                { "BELO HORIZONTE","25666~NETSALES_BASE_BH" },
                { "BENTO GONCALVES","67040~NETSALES_BASE_SUL" },
                { "BERTIOGA","05456~NETSALES_BASE_ABC" },
                { "BETIM","03514~NETSALES_BASE_ISP" },
                { "BIGUACU","07058~NETSALES_BASE_SUL" },
                { "BLUMENAU","75680~NETSALES_BASE_SUL" },
                { "BLUMENAU BTV","75681~NETSALES_BASE_SUL" },
                { "BOA VISTA","00156~NETSALES_BASE_ABC" },
                { "BOITUVA","05464~NETSALES_BASE_ABC" },
                { "BOTUCATU","05471~NETSALES_BASE_SOC" },
                { "BRAGANCA PAULISTA","05474~NETSALES_BASE_ABC" },
                { "BRASILIA","15890~NETSALES_BASE_BR" },
                { "BRUSQUE","07070~NETSALES_BASE_ISP" },
                { "CABEDELO","01833~NETSALES_BASE_ISP" },
                { "CABO FRIO","05115~NETSALES_BASE_SUL" },
                { "CACAPAVA","05487~NETSALES_BASE_ABC" },
                { "CACHOEIRA PAULISTA","05488~NETSALES_BASE_SOC" },
                { "CACHOEIRINHA","07560~NETSALES_BASE_SUL" },
                { "CACHOEIRO DE ITAPEMIRIM","04911~NETSALES_BASE_ISP" },
                { "CAIEIRAS","05498~NETSALES_BASE_SUL" },
                { "CAMACARI","02750~NETSALES_BASE_ISP" },
                { "CAMBE","06379~NETSALES_BASE_SUL" },
                { "CAMPINA GRANDE","01847~NETSALES_BASE_ISP" },
                { "CAMPINAS","05509~NETSALES_BASE_ISP" },
                { "CAMPO BOM","07584~NETSALES_BASE_ISP" },
                { "CAMPO GRANDE","08533~NETSALES_BASE_ISP" },
                { "CAMPO LARGO","06389~NETSALES_BASE_ISP" },
                { "CAMPOS DOS GOYTACAZES","05129~NETSALES_BASE_ISP" },
                { "CANELA","07601~NETSALES_BASE_SUL" },
                { "CANOAS","07603~NETSALES_BASE_ISP" },
                { "CAPAO DA CANOA","67784~NETSALES_BASE_SUL" },
                { "CAPIVARI","05530~NETSALES_BASE_SOC" },
                { "CARAGUATATUBA","05531~NETSALES_BASE_ABC" },
                { "CARAPICUIBA","05533~NETSALES_BASE_SOC" },
                { "CARAZINHO","07614~NETSALES_BASE_SUL" },
                { "CARIACICA","04917~NETSALES_BASE_ISP" },
                { "CARUARU","02152~NETSALES_BASE_ISP" },
                { "CASCAVEL","06413~NETSALES_BASE_SOC" },
                { "CASTANHAL","00233~NETSALES_BASE_SUL" },
                { "CATANDUVA","05543~NETSALES_BASE_SUL" },
                { "CAXIAS DO SUL","68020~NETSALES_BASE_SUL" },
                { "CHAPECO","76066~NETSALES_BASE_SUL" },
                { "CIANORTE","06430~NETSALES_BASE_SOC" },
                { "COLOMBO","06437~NETSALES_BASE_ISP" },
                { "CONSELHEIRO LAFAIETE","03741~NETSALES_BASE_ISP" },
                { "CONTAGEM","03753~NETSALES_BASE_ISP" },
                { "CORONEL FABRICIANO","03778~NETSALES_BASE_SUL" },
                { "COSMOPOLIS","05565~NETSALES_BASE_ISP" },
                { "COTIA","05567~NETSALES_BASE_SOC" },
                { "CRAVINHOS","05569~NETSALES_BASE_ABC" },
                { "CRICIUMA","76180~NETSALES_BASE_SUL" },
                { "CRUZ ALTA","68659~NETSALES_BASE_SUL" },
                { "CRUZEIRO","05572~NETSALES_BASE_SOC" },
                { "CUBATAO","05573~NETSALES_BASE_ABC" },
                { "CUIABA","08719~NETSALES_BASE_SOC" },
                { "CURITIBA - CABO","55298~NETSALES_BASE_SUL" },
                { "CURITIBA - MMDS","55299~NETSALES_BASE_SUL" },
                { "DESCALVADO","05576~NETSALES_BASE_ABC" },
                { "DIADEMA","05577~NETSALES_BASE_ABC" },
                { "DIVINOPOLIS","03832~NETSALES_BASE_ISP" },
                { "DOURADOS","08567~NETSALES_BASE_ISP" },
                { "DRACENA","05586~NETSALES_BASE_SUL" },
                { "DUQUE DE CAXIAS","05161~NETSALES_BASE_SOC" },
                { "ELIAS FAUSTO","05595~NETSALES_BASE_SOC" },
                { "EMBU DAS ARTES","05599~NETSALES_BASE_SOC" },
                { "ERECHIM","69019~NETSALES_BASE_SUL" },
                { "ESTANCIA VELHA","07757~NETSALES_BASE_ISP" },
                { "ESTEIO","07758~NETSALES_BASE_ISP" },
                { "FARROUPILHA","69337~NETSALES_BASE_SUL" },
                { "FEIRA DE SANTANA","02852~NETSALES_BASE_ISP" },
                { "FLORIANOPOLIS","76414~NETSALES_BASE_SUL" },
                { "FORTALEZA","01097~NETSALES_BASE_SOC" },
                { "FOZ DO IGUACU","06506~NETSALES_BASE_SUL" },
                { "FRANCA","05623~NETSALES_BASE_ISP" },
                { "GASPAR","07154~NETSALES_BASE_ISP" },
                { "GOIANIA","19887~NETSALES_BASE_BR" },
                { "GOVERNADOR VALADARES","03930~NETSALES_BASE_ISP" },
                { "GRAMADO","07817~NETSALES_BASE_SUL" },
                { "GRAVATAI","07820~NETSALES_BASE_ISP" },
                { "GUARAMIRIM","07163~NETSALES_BASE_SUL" },
                { "GUARAPUAVA","06531~NETSALES_BASE_SOC" },
                { "GUARATINGUETA","05656~NETSALES_BASE_SOC" },
                { "GUARUJA","05659~NETSALES_BASE_ABC" },
                { "GUARULHOS","05661~NETSALES_BASE_SOC" },
                { "HORTOLANDIA","05668~NETSALES_BASE_ABC" },
                { "INDAIATUBA","05693~NETSALES_BASE_ISP" },
                { "IPATINGA","04005~NETSALES_BASE_ISP" },
                { "ITAJAI","07193~NETSALES_BASE_ISP" },
                { "ITAJUBA","04024~NETSALES_BASE_SUL" },
                { "ITANHAEM","05712~NETSALES_BASE_ABC" },
                { "ITAPECERICA DA SERRA","05714~NETSALES_BASE_SOC" },
                { "ITAPEMA","07194~NETSALES_BASE_ISP" },
                { "ITAPETININGA","05715~NETSALES_BASE_ABC" },
                { "ITAPEVI","05722~NETSALES_BASE_SOC" },
                { "ITAQUAQUECETUBA","05733~NETSALES_BASE_ISP" },
                { "ITATIBA","05739~NETSALES_BASE_SUL" },
                { "ITU","05746~NETSALES_BASE_ABC" },
                { "ITUIUTABA","04060~NETSALES_BASE_ISP" },
                { "ITUVERAVA","05749~NETSALES_BASE_ABC" },
                { "JABOATAO DOS GUARARAPES","02235~NETSALES_BASE_ABC" },
                { "JACAREI","05756~NETSALES_BASE_ABC" },
                { "JAGUARIUNA","05761~NETSALES_BASE_ABC" },
                { "JANDIRA","05765~NETSALES_BASE_SOC" },
                { "JARAGUA DO SUL","07203~NETSALES_BASE_SUL" },
                { "JAU","05769~NETSALES_BASE_SOC" },
                { "JOAO PESSOA","01907~NETSALES_BASE_SOC" },
                { "JOINVILLE","77127~NETSALES_BASE_SUL" },
                { "JUIZ DE FORA","04126~NETSALES_BASE_ISP" },
                { "JUNDIAI","05776~NETSALES_BASE_ISP" },
                { "LAGES","07213~NETSALES_BASE_SUL" },
                { "LAGOA SANTA","04143~NETSALES_BASE_ISP" },
                { "LAJEADO","70408~NETSALES_BASE_SUL" },
                { "LAURO DE FREITAS","03042~NETSALES_BASE_SOC" },
                { "LIMEIRA","05791~NETSALES_BASE_ABC" },
                { "LONDRINA","56995~NETSALES_BASE_SUL" },
                { "LORENA","05795~NETSALES_BASE_SOC" },
                { "LOUVEIRA","05798~NETSALES_BASE_SUL" },
                { "LUCAS DO RIO VERDE","08756~NETSALES_BASE_ABC" },
                { "MACAE","05197~NETSALES_BASE_ISP" },
                { "MACAPA","00393~NETSALES_BASE_SUL" },
                { "MACEIO","02480~NETSALES_BASE_SOC" },
                { "MAIRINQUE","05810~NETSALES_BASE_ABC" },
                { "MANAUS","00121~NETSALES_BASE_ABC" },
                { "MARABA","00272~NETSALES_BASE_SUL" },
                { "MARILIA","05820~NETSALES_BASE_SOC" },
                { "MARINGA","57304~NETSALES_BASE_SUL" },
                { "MAUA","05833~NETSALES_BASE_ABC" },
                { "MESQUITA","05239~NETSALES_BASE_SOC" },
                { "MIRASSOL","05850~NETSALES_BASE_ABC" },
                { "MOGI DAS CRUZES","05856~NETSALES_BASE_ABC" },
                { "MOGI GUACU","05863~NETSALES_BASE_ABC" },
                { "MOGI MIRIM","05865~NETSALES_BASE_ABC" },
                { "MONGAGUA","05869~NETSALES_BASE_ABC" },
                { "MONTE MOR","05882~NETSALES_BASE_SOC" },
                { "MONTENEGRO","07950~NETSALES_BASE_SUL" },
                { "MONTES CLAROS","04275~NETSALES_BASE_ISP" },
                { "NATAL","01695~NETSALES_BASE_SOC" },
                { "NAVEGANTES","07260~NETSALES_BASE_ISP" },
                { "NILOPOLIS","05226~NETSALES_BASE_SOC" },
                { "NITEROI","05228~NETSALES_BASE_BR" },
                { "NOVA FRIBURGO","05230~NETSALES_BASE_ISP" },
                { "NOVA IGUACU","05237~NETSALES_BASE_SOC" },
                { "NOVA LIMA","04312~NETSALES_BASE_ISP" },
                { "NOVA ODESSA","05910~NETSALES_BASE_SUL" },
                { "NOVO HAMBURGO - CABO","71242~NETSALES_BASE_SUL" },
                { "NOVO HAMBURGO - MMDS","71243~NETSALES_BASE_SUL" },
                { "OLINDA","02269~NETSALES_BASE_ABC" },
                { "ORLANDIA","05923~NETSALES_BASE_ABC" },
                { "OSASCO","05924~NETSALES_BASE_SOC" },
                { "PALHOCA","07278~NETSALES_BASE_ISP" },
                { "PALMAS","00540~NETSALES_BASE_ISP" },
                { "PARANAGUA","06749~NETSALES_BASE_SUL" },
                { "PARNAMIRIM","01637~NETSALES_BASE_SOC" },
                { "PASSO FUNDO","71587~NETSALES_BASE_SUL" },
                { "PAULINIA","05954~NETSALES_BASE_ISP" },
                { "PAULISTA","02291~NETSALES_BASE_ABC" },
                { "PEDREIRA","05966~NETSALES_BASE_ABC" },
                { "PELOTAS","71706~NETSALES_BASE_SUL" },
                { "PERUIBE","05972~NETSALES_BASE_ABC" },
                { "PETROPOLIS","05250~NETSALES_BASE_ISP" },
                { "PINDAMONHANGABA","05976~NETSALES_BASE_ABC" },
                { "PINHAIS","06770~NETSALES_BASE_ISP" },
                { "PIRACICABA","05985~NETSALES_BASE_ISP" },
                { "POA","06009~NETSALES_BASE_ISP" },
                { "POCOS DE CALDAS","04437~NETSALES_BASE_SUL" },
                { "PONTA GROSSA","06794~NETSALES_BASE_SOC" },
                { "PORTO ALEGRE - CABO","71986~NETSALES_BASE_SUL" },
                { "PORTO ALEGRE - MMDS","71987~NETSALES_BASE_SUL" },
                { "PORTO FELIZ","06022~NETSALES_BASE_SOC" },
                { "PORTO VELHO","00022~NETSALES_BASE_ISP" },
                { "POTIM","06024~NETSALES_BASE_SOC" },
                { "POUSO ALEGRE","04459~NETSALES_BASE_SUL" },
                { "PRAIA GRANDE","06027~NETSALES_BASE_ABC" },
                { "PRESIDENTE PRUDENTE","06036~NETSALES_BASE_ISP" },
                { "RAFARD","06048~NETSALES_BASE_SOC" },
                { "RECIFE","51136~NETSALES_BASE_ABC" },
                { "RESENDE","05268~NETSALES_BASE_ABC" },
                { "RIBEIRAO PIRES","06067~NETSALES_BASE_ISP" },
                {"RIBEIRAO PRETO", "06070~NETSALES_BASE_ISP"},
                {"RIO BRANCO", "00066~NETSALES_BASE_ISP"},
                {"RIO CLARO", "06076~NETSALES_BASE_ABC"},
                {"RIO DAS OSTRAS", "05285~NETSALES_BASE_ISP"},
                {"RIO DE JANEIRO", "63118~NETSALES_BASE_BR"},
                {"RIO GRANDE", "72451~NETSALES_BASE_SUL"},
                {"RIO VERDE", "09112~NETSALES_BASE_SUL"},
                {"ROLANDIA", "06851~NETSALES_BASE_SUL"},
                {"RONDONOPOLIS", "08818~NETSALES_BASE_ISP"},
                {"SABARA", "04541~NETSALES_BASE_ISP"},
                {"SALTO", "06095~NETSALES_BASE_SOC"},
                {"SALTO DE PIRAPO", "06096~NETSALES_BASE_ABC"},
                {"SALVADOR", "03230~NETSALES_BASE_SOC"},
                {"SANTA BARBARA D OESTE", "06103~NETSALES_BASE_ABC"},
                {"SANTA BRANCA", "06104~NETSALES_BASE_ABC"},
                {"SANTA CRUZ DO RIO PARDO", "06108~NETSALES_BASE_ABC"},
                {"SANTA CRUZ DO SUL", "72842~NETSALES_BASE_SUL"},
                {"SANTA MARIA", "72907~NETSALES_BASE_SUL" },
                {"SANTANA DE PARNAIBA", "06121~NETSALES_BASE_SOC"},
                {"SANTO ANDRE", "06129~NETSALES_BASE_ABC" },
                {"SANTOS", "06139~NETSALES_BASE_BR"},
                {"SANTOS ABC", "89897~NETSALES_BASE_ABC"},
                {"SAO BERNARDO DO CAMPO", "06141~NETSALES_BASE_ABC"},
                {"SAO CAETANO DO SUL", "06143~NETSALES_BASE_ABC"},
                {"SAO CARLOS", "06144~NETSALES_BASE_ISP"},
                { "SAO GONCALO", "05305~NETSALES_BASE_ISP"},
                {"SAO JOAO DE MERITI","05316~NETSALES_BASE_SOC" },
                {"SAO JOAQUIM DA BARRA","06154~NETSALES_BASE_ABC"},
                {"SAO JOSE", "07363~NETSALES_BASE_ISP"},
                {"SAO JOSE DO RIO PRETO", "06158~NETSALES_BASE_ISP"},
                {"SAO JOSE DOS CAMPOS", "06162~NETSALES_BASE_ABC"},
                {"SAO JOSE DOS PINHAIS", "06923~NETSALES_BASE_ISP"},
                {"SAO LEOPOLDO - CABO", "89710~NETSALES_BASE_ISP"},
                {"SAO LEOPOLDO - MMDS", "73466~NETSALES_BASE_SUL"},
                {"SAO LUIS", "00696~NETSALES_BASE_SOC"},
                {"SAO MIGUEL ARCANJO", "06171~NETSALES_BASE_SUL"},
                {"SAO PAULO", "88412~NETSALES_BASE_SP"},
                {"SAO PEDRO DA ALDEIA", "05320~NETSALES_BASE_SUL"},
                {"SAO ROQUE", "06178~NETSALES_BASE_SUL"},
                {"SAO SEBASTIAO", "06182~NETSALES_BASE_ABC"},
                {"SAO VICENTE", "06187~NETSALES_BASE_ABC"},
                {"SAPIRANGA", "08330~NETSALES_BASE_ISP"},
                {"SAPUCAIA DO SUL", "08332~NETSALES_BASE_ISP"},
                {"SERRA", "05066~NETSALES_BASE_ISP"},	
                {"SERRA NEGRA", "88579~NETSALES_BASE_ABC"},							
                {"SERTAOZINHO", "06195~NETSALES_BASE_SOC"},							
                {"SETE LAGOAS", "04742~NETSALES_BASE_ISP"},							
                {"SINOP", "08837~NETSALES_BASE_SUL"},	
                {"SOBRAL", "01521~NETSALES_BASE_SUL"},		
                {"SOROCABA", "06201~NETSALES_BASE_SOC"},
                {"SORRISO", "08838~NETSALES_BASE_SUL"},			
                {"SUMARE", "06207~NETSALES_BASE_ABC"},		
                {"SUZANO", "06209~NETSALES_BASE_ISP"},		
                {"TABOAO DA SERRA", "06216~NETSALES_BASE_SOC"},						
                {"TATUI", "06233~NETSALES_BASE_SUL"},	
                {"TAUBATE", "06235~NETSALES_BASE_ABC"},			
                {"TEOFILO OTONI", "04763~NETSALES_BASE_ISP"},
                {"TERESINA","00863~NETSALES_BASE_SOC"},
                {"TERESOPOLIS","05338~NETSALES_BASE_ISP"},
                {"TIETE","06241~NETSALES_BASE_SOC"},
                {"TIMOTEO","04770~NETSALES_BASE_ABC"},
                {"TORRES","08398~NETSALES_BASE_SUL"},
                {"TREMEMBE","06246~NETSALES_BASE_SUL"},
                {"TRES CORACOES","04780~NETSALES_BASE_SUL"},
                {"UBATUBA","06261~NETSALES_BASE_ABC"},
                {"UBERABA","04803~NETSALES_BASE_ISP"},
                {"UBERLANDIA","04806~NETSALES_BASE_ISP"},
                {"URUGUAIANA","74748~NETSALES_BASE_SUL"},
                {"VALINHOS","06272~NETSALES_BASE_SOC"},
                {"VARGEM GRANDE PAULISTA","06276~NETSALES_BASE_SOC"},
                {"VARGINHA","04821~NETSALES_BASE_SUL"},
                {"VARZEA GRANDE","08858~NETSALES_BASE_SOC"},
                {"VARZEA PAULISTA","06277~NETSALES_BASE_SUL"},
                {"VESPASIANO","04834~NETSALES_BASE_ISP"},
                {"VIA EMBRATEL","02121~NETSALES_BASE_CTV"},
                {"VIAMAO","08471~NETSALES_BASE_SUL"},
                {"VILA VELHA","05078~NETSALES_BASE_SOC"},
                {"VINHEDO","06279~NETSALES_BASE_SUL"},
                {"VITORIA","05083~NETSALES_BASE_SOC"},
                {"VITORIA DA CONQUISTA","03363~NETSALES_BASE_ISP"},
                {"VOLTA REDONDA","05359~NETSALES_BASE_ISP"},
                {"VOTORANTIM","06282~NETSALES_BASE_SUL"},
                {"XANGRI-LA","08493~NETSALES_BASE_SUL"},
            };

            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            try
            {
                foreach (var item in cidades)
                {
                    SQLiteCommand command = new SQLiteCommand($"INSERT INTO cidades (name, dbService) VALUES('{item.Key.ToString()}', '{item.Value.ToString()}')", conexao);
                    command.ExecuteNonQuery();
                }
            }
            catch{
                conexao.Close();
            }
            conexao.Close();
        }
        private void tablesSeedersEstados()
        {
            string[] estados = new string[] 
            {
                "AC",
                "AL",
                "AM",
                "AP",
                "BA",
                "CE",
                "DF",
                "ES",
                "GO",
                "MA",
                "MG",
                "MS",
                "MT",
                "PA",
                "PB",
                "PE",
                "PI",
                "PR",
                "RJ",
                "RN",
                "RO",
                "RR",
                "RS",
                "SC",
                "SE",
                "SP",
                "TO"
        };

            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            try
            {
                for (int i = 0; i < estados.Count(); i++)
                {
                    SQLiteCommand command = new SQLiteCommand($"INSERT INTO estados (name) VALUES('{estados[i]}')", conexao);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                conexao.Close();
            }
            conexao.Close();
        }
        public DataTable Query(string query)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();
                SQLiteCommand command = new SQLiteCommand(query, conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatableDominios = new DataTable();
                da.Fill(datatableDominios);
                conexao.Close();
                return datatableDominios;
            }
            catch
            {
                return null;
            }
        }
        public void ExecuteSqlCommand(string query)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();
                SQLiteCommand command = new SQLiteCommand(query, conexao);
                command.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

            }
        }
        public DataTable paginate(int page, int id_dominio_ngestor, int id_sistemas_tipo)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND id_sistemas_tipo = {id_sistemas_tipo} limit {limit} offset {page}", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);

                SQLiteCommand countRows = new SQLiteCommand($"SELECT count(id_sistemas_tipo) FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND id_sistemas_tipo = {id_sistemas_tipo}", conexao);
                countRows.CommandType = CommandType.Text;

                countOs = Convert.ToInt32(countRows.ExecuteScalar());
                conexao.Close();
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<string> getFilters(int id_dominio_ngestor, int id_sistemas_tipo)
        {
            List<string> tipos_servico_f = new List<string>();
            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            SQLiteCommand command = new SQLiteCommand($"SELECT tipo_servico FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND  id_sistemas_tipo = {id_sistemas_tipo}", conexao);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            tipos_servico_f.Clear();
            tipos_servico_f.Add("Todos");
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                if (!tipos_servico_f.Contains(datatable.Rows[i][0].ToString()))
                {
                    tipos_servico_f.Add(datatable.Rows[i][0].ToString());
                }
            }
            conexao.Close();
            return tipos_servico_f;
        }
        public DataTable SelectFromFilters(int id_dominio_ngestor, string os_selected_f, int id_sistemas_tipo)
        {
            if (os_selected_f == "Todos")
            {
                return selectAllSemPaginate(id_dominio_ngestor, id_sistemas_tipo);
            }

            try
            {

                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{id_dominio_ngestor}' AND id_sistemas_tipo = {id_sistemas_tipo} AND tipo_servico = '{os_selected_f}'", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                return datatable;
                conexao.Close();
            }
            catch { }
            return null;
        }
        private DataTable selectAllSemPaginate(int id_dominio_ngestor, int id_sistemas_tipo)
        {
            try
            {

                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{id_dominio_ngestor}' AND id_sistemas_tipo = {id_sistemas_tipo}", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                conexao.Close();
                return datatable;

            }
            catch { }
            return null;
        }

    }
}
