using Unity.Netcode.Components;

public class ClientNetworktTransform : NetworkTransform
{
    protected override bool OnIsServerAuthoritative(){
        return false;
    }
}
