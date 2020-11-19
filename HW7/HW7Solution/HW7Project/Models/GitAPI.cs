using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HW7Project.Models
{
    public class GitAPI {
        public string source {get; set;}

        public string credentials {get; set;}

        public string userName {get; set;}

       
        public GitAPI(string source, string userName, string token) {
            this.source = source;
            this.userName = userName;
            this.credentials = token;
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        public IEnumerable<Repo> Repos() {
            string request = SendRequest(source, credentials, userName);

            Console.WriteLine(request);
            return null;
        }

        public Account userInfo() {
            string info = SendRequest(source, credentials, userName);
            var json = JObject.Parse(info);
            Account user = new Account();
            user.userName = json["login"].ToString();
            user.name = json["name"].ToString();
            user.email = json["email"].ToString();
            user.location = json["location"].ToString();
            user.company = json["company"].ToString();
            user.avatar = json["avatar_url"].ToString();

            return user;
        }

        public IEnumerable<Repo> repoInfo() {
            string info = SendRequest(source, credentials, userName);
            var json = JArray.Parse(info);
            List<Repo> repos = new List<Repo>();
            
            foreach(var repo in json)
            {
                Repo r = new Repo();
                r.owner = repo["owner"]["login"].ToString();
                r.repoName = repo["name"].ToString();
                r.update = repo["updated_at"].ToString();
                r.picture = repo["owner"]["avatar_url"].ToString();
                r.repoURL = repo["html_url"].ToString(); 
                repos.Add(r);
            }
            return repos;
        }

        public IEnumerable<Commit> CommitInfo()
        {
            string info = SendRequest(source, credentials, userName);
            var json = JArray.Parse(info);
            List<Commit> commits = new List<Commit>();
            foreach(var commit in json)
            {
                Commit c = new Commit();
                c.SHA = commit["sha"].ToString();
                c.committee = commit["commit"]["committer"]["name"].ToString();
                c.timeStamp = commit["commit"]["committer"]["date"].ToString();
                c.message = commit["commit"]["message"].ToString();
                c.shaURL = commit["html_url"].ToString();
                commits.Add(c);
            }
            return commits;
        }
        
    }
}