using Prompton.Steps;

namespace Prompton
{
    public class MockDeserializer : IYamlDeserializer
    {
        private Dictionary<string, Step> dicToReturn;
        private MainStep mainToReturn;

        public MockDeserializer(Dictionary<string, Step> dicToReturn, MainStep mainToReturn)
        {
            this.dicToReturn = dicToReturn;
            this.mainToReturn = mainToReturn;
        }

        public Dictionary<string, Step> GetStepDictionary(params string[] filepaths)
        {
            return dicToReturn;
        }
        public MainStep GetMain(params string[] filepaths)
        {
            return mainToReturn;
        }
    }
}
