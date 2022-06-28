using System;

public class NftExternalMetadata
{
    [Serializable]
    public class Rootobject
    {
        public Data data;
        public bool error;
        public object error_message;
        public object error_code;
    }
    [Serializable]
    public class Data
    {
        public string updated_at;
        public Item[] items;
        public object pagination;
    }
    [Serializable]
    public class Item
    {
        public int contract_decimals;
        public string contract_name;
        public string contract_ticker_symbol;
        public string contract_address;
        public string[] supports_erc;
        public string logo_url;
        public string type;
        public Nft_Data[] nft_data;
    }
    [Serializable]
    public class Nft_Data
    {
        public string token_id;
        public string token_balance;
        public string token_url;
        public string[] supports_erc;
        public object token_price_wei;
        public object token_quote_rate_eth;
        public string original_owner;
        public External_Data external_data;
        public string owner;
        public string owner_address;
        public bool burned;
    }
    [Serializable]
    public class External_Data
    {
        public object name;
        public object description;
        public string image;
        public string image_256;
        public string image_512;
        public string image_1024;
        public object animation_url;
        public object external_url;
        public Attribute[] attributes;
        public object owner;
    }
    [Serializable]
    public class Attribute
    {
        public string trait_type;
        public string value;
    }
}