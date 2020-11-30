$(document).ready(

    () => {
        gitUserAjax();
        gitRepoAjax();
    }
);

function gitUserAjax() {
    $.getJSON("/api/user", 
        function (data) {
            console.log(data);
            $("#userName").append(data.userName);
            $("#name").append(data.name);
            $("#email").append(data.email);
            $("#avatar").append(`<img src="${data.avatar}" style="height:195px; width: 200px"></img>`);
            $("#location").append(data.location);
            $("#company").append(data.company);
        }
    );
} 

function gitRepoAjax() {
    $.getJSON("/api/repositories",
        function(data) {
            console.log(data);

            for(let i = 0; i < data.length; i++) 
            {
                let div = `<div class="card bg-info text-white" id="${data[i].repoName} style="background-color: darkorchid>    
                    <a href="${data[i].repoURL}" id="repoName${i}" style="margin-top: 15px"><h7 class="card-title">${data[i].repoName}</h7></a>
                    <br>
                    <p id="owner${i}">${data[i].owner} <br> <i>Updated on:</i> ${data[i].update}</p> 
                    <img src="${data[i].picture}" id="picture${i}"  style="height:60px; width: 60px;float:right;"><img>
                    <br>
                    <button type="button" onclick="gitCommits('${data[i].repoName}', '${data[i].owner}')" class="btn btn-danger" style="border-radius: 5%;">Commits</button>
                </div>`;
                $("#parent").append(div);
            }
        }
    );
}
 
function gitCommits(repoName, owner) {
    console.log(owner);
    $.getJSON("/api/commits?repoName="+repoName+"&owner="+owner, 
    function(data) 
    {       
        $("#repoCommit").empty();
        $("#repoCommit").append(repoName);
        $("#commits > tbody").empty();
            for(let i = 0; i < data.length; i++) 
            {
                let tr = `<tr>
                    <td><a href="${data[i].shaURL}">${data[i].sha.substr(0,8)}</a></td>
                    <td style="width: auto;">${data[i].timeStamp}</td>
                    <td>${data[i].committee}</td>
                    <td>${data[i].message}</td>
                </tr>`;

                $("#commits").last().append(tr);
            }
        }
    );
}