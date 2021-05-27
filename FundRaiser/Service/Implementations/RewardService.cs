using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;

namespace FundRaiser.Service.Implementations
{
    public class RewardService : IRewardService
    {
        private readonly FundRaiserDbContext _db;

        public RewardService(FundRaiserDbContext db)
        {
            _db = db;
        }
        public RewardOption CreateReward(RewardOption rewardOptions)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReward(int rewardId)
        {
            throw new NotImplementedException();
        }

        public RewardOption GetRewardById(int rewardId)
        {
            throw new NotImplementedException();
        }

        public RewardOption UpdateReward(int rewardId, RewardOption rewardOptions)
        {
            throw new NotImplementedException();
        }
    }
}
