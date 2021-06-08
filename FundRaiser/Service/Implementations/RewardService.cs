using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;
using Microsoft.EntityFrameworkCore;

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

            Project project = _db.Projects.Find(rewardOptions.ProjectId);
            Reward reward = new()
            {
                Title = rewardOptions.Title,
                Description = rewardOptions.Description,
                AmountRequired = rewardOptions.AmountRequired,
                Project = project
            };
            _db.Rewards.Add(reward);
            _db.SaveChanges();
            return new RewardOption(reward);
        }

        public RewardOption GetRewardById(int rewardId)
        {
            Reward reward = _db.Rewards.Include(p => p.Project).FirstOrDefault(o => o.RewardId == rewardId);
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

        public List<RewardOption> GetRewardsByProjectId(int projectId)
        {
            return RewardToRewardOptions(_db.Rewards.Include(p => p.Project).Where(r => r.Project.ProjectId == projectId).ToList());
        }

        public List<RewardOption> GetRewardsByUserId(int userId)
        {
            return RewardToRewardOptions(_db.Transactions.Include(p => p.Project).Include(p=>p.Reward.Project).Where(t => t.User.UserId == userId).Select(r => r.Reward).Distinct().ToList());
        }

        public List<RewardOption> RewardToRewardOptions(List<Reward> rewards)
        {
            List<RewardOption> rewardOptions = new List<RewardOption>();
            rewards.ForEach(reward => rewardOptions.Add(new RewardOption(reward)));
            return rewardOptions;
        }

    }
}
