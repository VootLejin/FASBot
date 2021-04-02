using System;
using System.Collections.Generic;
using System.Text;

namespace FASBot
{
    public class WeightRepo
    {
        Dictionary<string, List<double>> _userNameToWeights = new Dictionary<string, List<double>>();

        public void Add(string userName, double weight)
        {
            if (!_userNameToWeights.ContainsKey(userName))
            {
                _userNameToWeights.Add(userName, new List<double>());
            }

            var weights = _userNameToWeights[userName];
            weights.Add(weight);
        }

        internal IEnumerable<double> GetWeights(string userName)
        {
            return _userNameToWeights[userName];
        }

        internal bool HasUser(string userName)
        {
            return _userNameToWeights.ContainsKey(userName);
        }
    }
}
