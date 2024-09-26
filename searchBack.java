package pokeApp;

public class searchBack{


    String pokeName;

    public searchBack(){}

    public searchBack(String pokeName){
        this.pokeName = pokeName;
    }

    public String getPokeName() throws Exception{
        if(pokeName == null){ //ISNT FOUND IN THE DATABASE
            throw new Exception("Pokemon does not exist");
        }
        else{
            return pokeName;
        }
    }

}