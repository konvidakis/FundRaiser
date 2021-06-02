using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;

namespace FundRaiser.Service
{
    public interface IRewardService
    {
        public RewardOption CreateReward(RewardOption rewardOptions);

        public RewardOption GetRewardById(int rewardId);

        public RewardOption UpdateReward(int rewardId, RewardOption rewardOptions);

        public bool DeleteReward(int rewardId);

        //public List<Reward> GetRewardsByProjectId(int projectId);

        //public List<Reward> GetRewardsByUserId(int userId);
    }
}
