const baseUrl = "https://localhost:5001/api/Song";

//use put for favorite 

function handleOnLoad() 
{
	populateList()
}

// function handleEditSave(id)
// {
	
// }
// function handleEditSearch(id)
// {

// }
function deleteSong(){ //this helps to delete the book
    const deleteSongApiUrl = baseUrl;
    fetch(deleteSongApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        blankFields(); //empty fields
        populateList(); //fill them back up with updated data
    });
}

// function getSongs(){
//     fetch(baseUrl).then(function(response) 
// 	{
// 		return response.json();
// 	}).then(function(json) 
// 	{
//         console.log(json);
// 	}).catch(function(error) 
// 	{
// 		console.log(error);
// 	})}

// function findSongs() //finding the songs! Called in the HTML
// {
	
// 	const songTitle = {SongTitle: document.getElementById("title").value}

//     fetch(baseUrl,
// 	{
// 		method: "POST",
// 		headers: 
// 		{
// 			"Accept": 'application/json',
// 			"Contenet-Type": 'application/jason'
// 		},
// 		body: JSON.stringify(songTitle)
// 	})
// 		.then((response)=>
// 		{
// 			console.log(response);
// 			getSongs();
// 		})
// }

function postSongs() //creating/add
{
	//console.log("you made this");
	const creatingSongAPI = baseUrl;
	const makingSong = {SongTitle : document.getElementById("title").value}
	console.log(songTitle);
    fetch(creatingSongAPI,
	{
		method: "POST",
		headers: 
		{
			"Accept": 'application/json',
			"Contenet-Type": 'application/jason'
		},
		body: JSON.stringify(songTitle)
	})
		.then((response)=>
		{
			newSong = makingSong;
			console.log(newSong);
			// console.log(response);
			// getSongs();
		})
		.then((res)=> res.text())
		.then((json)=>{
			console.log(json)
			let html = ``;
		// create new card
		const newCard = document.createElement('div'); //this is creatinga  new div
		newCard.className ="<div class=card col-md-4 bg-dark text-white"; //setting the type of card it wll be
		card.innerHTML =`
		<img src="./resources/images/music.jpeg" class="card-img" alt="..."/>
		<div class "card-img-oveerlay">
		<h5 class="card-title">${songTitle} ID:${songID}
		</div>`
	})

// 	// 	<div id="search" class="container">
//     //     <form onsubmit="false;">
//     //         <label class="form-label" for="searchSong">Find a song here:</label><br>
//     //         <input class="form-control" type="text" id="searchSong" name="searchSong" ><br>
//     //         <button class="btn btn-dark" onclick="findSongs()">Find Song</button>
//     //       </form>
//     // </div>
 }
function editSongs(){
    fetch(baseUrl).then(function(response) {
		return response.json();
	}).then(function(json) {
        console.log(json);
	}).catch(function(error) {
		console.log(error);
	})
}

function deleteSongs()
{
	fetch(baseUrl).then(function(response) 
	{
		return response.json();
	}).then(function(json) 
	{
		console.log(json);
	}).catch(function(error) 
	{
		console.log(error);
	})
}
function populateList()
{ //this was to fill the boxes on the page

    // const allSongs = baseUrl;
    fetch(baseUrl).then(function(response){
        return response.json();
    }).then(function(json){
        songList = json;
        let html = "<select class = \"listBox\" onchange = \"handleOnChange()\" id= \"selectListBox\" name = \"list_box\" size=5 width=\"100%\">";
        json.forEach((song)=>{
            html += "<option value = " + song.SongID  + ">" + song.songTitle+ "</option>";
        })
        html += "</select>";
        document.getElementById("listBox").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//havent tried this and i dont really know if this works XOXO


// let html = ``;
		// json.forEach((song) => {
        //     console.log(song.title)
        //     html += `<div class="card col-md-4 bg-dark text-white">`;
		// 	html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
		// 	html += `<div class="card-img-overlay">`;
		// 	html += `<h5 class="card-title">`+song.title+`</h5>`;
        //     html += `</div>`;
        //     html += `</div>`;
		// });
		
        // if(html === ``){
        //     html = "No Songs found :("
        // }
		// document.getElementById("searchSongs").innerHTML = html;)
		//}
	
function blankFields() //makes the fields blank 
{
	document.getElementById("SongID").value="";
	document.getElementById("SongTitle").value="";
	document.getElementById("SongTimeStamp").value="";
	document.getElementById("Deleted").value="";
	document.getElementById("Favorited").value="";
}
function populateForm(){ //fills the form after a new book is created or after an edit is made
    document.getElementById("SongID").value = newSongs.SongID;
    document.getElementById("SongTitle").value = newSongs.SongTitle;
    document.getElementById("SongTimeStamp").value = newSongs.SongTimeStamp;
    document.getElementById("Deleted").value = newson.deleteSong;
    document.getElementById("Favorited").value = mySong.Favorited;
    // var html= "<img class= \"coverArt\" src= \"" + myBook.cover + "\"></img>";
    // document.getElementById("picBox").innerHTML = html;

}
		