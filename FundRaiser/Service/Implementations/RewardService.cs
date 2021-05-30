using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;

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
            if (rewardOptions == null)
            {
                return null;
            }

            Reward reward = rewardOptions.GetRewardOption();
            _db.Rewards.Add(reward);
            _db.SaveChanges();
            return new RewardOption(reward);
        }

        public RewardOption GetRewardById(int rewardId)
        {
            Reward reward= _db.Rewards.Find(rewardId);
            if (reward == null)
            {
                return null;
            }

            return new RewardOption(reward);
        }

        public RewardOption UpdateReward(int rewardId, RewardOption rewardOptions)
        {
            Reward dbReward = _db.Rewards.Find(rewardId);
            if (dbReward == null)
            {
                return null;
            }
            dbReward.Title = rewardOptions.Title;
            dbReward.Description = rewardOptions.Description;
            dbReward.AmountRequired = rewardOptions.AmountRequired;
            _db.SaveChanges();

            return new RewardOption(dbReward);
        }
        public bool DeleteReward(int rewardId)
        {
            Reward dbReward = _db.Rewards.Find(rewardId);
            if (dbReward == null)
            {
                return false;
            }

            _db.Rewards.Remove(dbReward);
            _db.SaveChanges();
            return true;
        }
    }
}
