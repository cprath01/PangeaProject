//using Octokit;
using MQConsumerService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposAPIService
{
    public static class RepoExtensions
    {
        public static void Limit(this IEnumerable<Repository> repos, string repoList)
        {
            if (repoList != null)
            {
                var limitList = new List<string>(repoList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                var copyRepos = (List<Repository>)repos;

                if (copyRepos != null)
                {
                    copyRepos.RemoveAll(r => !limitList.Contains(r.name));
                }
                else
                {
                    var copy2Repos = (Repository[])repos;
                    if (copy2Repos != null)
                    {
                        var list = new List<Repository>();
                        foreach (var repo in copy2Repos)
                        {
                            if (limitList.Contains(repo.name))
                            {
                                list.Add(repo);
                            }
                        }

                        repos = list.ToArray();
                    }
                }

                throw new Exception("Wrong IEnumerable Type");
            }
        }
    }
}
