#pragma strict
var imageFolderName = "";
var MakeTexture = false;
var pictures = new Array();
var loop = false;
var counter = 0;
var Film = true;
var PictureRateInSeconds:float = 1;
private var nextPic:float = 0;
 
function Start () {
    if(Film == true){
        PictureRateInSeconds =  0.1;
    }
 
    var textures : Object[] = Resources.LoadAll(imageFolderName);
    for(var i = 0; i < textures.Length; i++){
        Debug.Log("found");
        pictures.Add(textures[i]);
    }
}
 
function Update () 
{
    if(Time.time > nextPic)
    {
        nextPic = Time.time + PictureRateInSeconds;
        counter += 1;
        if(counter >= pictures.length)
        {
        	if(loop)
        	{
        	    counter = 0;
        	}
    	}
        if(MakeTexture)
        {
            renderer.material.mainTexture = pictures[counter];
        }
    }
}