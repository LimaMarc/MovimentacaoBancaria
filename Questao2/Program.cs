using Newtonsoft.Json;
using Questao2;

public class Program
{
    //A boa prática é parametrizar essas informações de Urls, endpoints, tokens, headers no arquivo de configuração
    //ou cadastrados nas variáveis de ambiente dentro do Pipeline de Publicação, por exemplo Azure Devops ou parametrizar nos arquivos de configuração
    //das aplicações ... appConfig, releaseConfig.json e etc
    //como aqui se trata de um projeto simples, optei por deixar como atributo somente leitura da classe
    static readonly string _baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";


    public static void Main()
    {

        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = GetTotalScoredGoals(teamName, year);
        
        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);
        Console.WriteLine("-------------------------");

        teamName = "Chelsea";
        year = 2014;
        totalGoals = GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);
        Console.WriteLine("-------------------------");


        teamName = "Galatasaray";
        year = 2015;
        totalGoals = GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);
        Console.WriteLine("-------------------------");


        //Observação: API não está retornando o total de gols na temporada de um time e sim..
        //A api está retornando a quantidade de Gols do time numa competição
        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }




    public  static int GetTotalScoredGoals(string team, int year)
    {
        int scoredGoalsResult = 0;

        //Observação: API não está retornando o total de gols na temporada de um time e sim..
        //A api está retornando a quantidade de Gols do time numa competição
        var scoreResponse = RequestTotalScoredGoalsAsync(team, year).Result;
             
        foreach (var goal in scoreResponse.data.Select(x => x.team1goals).AsQueryable())
        {
            scoredGoalsResult += int.Parse(goal);
        }
        return scoredGoalsResult;
   
    }


    //Optei por criar um novo método do tipo Task
    //E recuperar o resultado da task no Client(Método getTotalScoredGoals)
    private async static Task<ScoreResponse> RequestTotalScoredGoalsAsync(string team, int year)
    {
       
        //Maneira simples. Em projetos reais é comuntente usar IHttpClientFactory
        //Parametrização das URI e endpoint em arquivos de configuração
        HttpClient client = new()
        {
            BaseAddress = new Uri(_baseUrl)
        };


        //maneira bem trivial sem muita sofisticação
        string queryString = $"?year={year}&team1={team}";

        try
        {
            var taskResult = await client.GetAsync(queryString);

            if (!taskResult.IsSuccessStatusCode)
                throw new ApplicationException(String.Concat("Erro ao comunicar com Api"," Status code: ",taskResult.StatusCode));
                                 
                      
            var deserializedObject = JsonConvert.DeserializeObject<ScoreResponse>(taskResult.Content.ReadAsStringAsync().Result);

            return deserializedObject == null ? throw new ApplicationException("Nenhum dado encontrado") : deserializedObject;
        }
        catch (Exception ex)
        {
            //Normalmente eu utilizo algum notification patterns e nunca exibo a stack da exception para cliente, pois 
            //algum atacante ou usuário malicioso pode obter informações sensíveis, por exemplo dados de servidor, ip, porta e etc.
            throw new ApplicationException("Erro Sistêmico ao realizar comunicação com Api. Mais Detalhe consulte a pilha de exceção", ex);
        }

    }

}