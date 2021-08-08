using Prompton.Models;
using System.Collections.Generic;

namespace Prompton
{
    public class MockDeserializer : IYamlDeserializer
    {
        private Dictionary<string, Step> dicToReturn;
        private Main mainToReturn;

        public MockDeserializer(Dictionary<string, Step> dicToReturn, Main mainToReturn)
        {
            this.dicToReturn = dicToReturn;
            this.mainToReturn = mainToReturn;
        }

        public Dictionary<string, Step> GetStepDictionary(params string[] filepaths)
        {
            return dicToReturn;
        }
        public Main GetMain(params string[] filepaths)
        {
            return mainToReturn;
        }
    }
}
