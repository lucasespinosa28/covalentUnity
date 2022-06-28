public class ParseUrl
{
    public static (bool, string) NFTExternalMetadata(Enumeration.ChainId chainId, string address, int id)
    {
        return address.Length > 0 && Data.Apikey.Length > 0
            ? (
                true,
            $"https://api.covalenthq.com/v1/{(int)chainId}/tokens/{address}/nft_metadata/{id}/?quote-currency=USD&format=JSON&key={Data.Apikey}"
                )
            : (false, "Error");
    }
    //
}
