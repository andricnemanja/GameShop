using GameShop.Backend.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameShop.Backend.Model
{
    public class GlobalSettingsDatabase
    {

        private string serializationFileName;

        public GlobalSettingsDatabase(string serializationFileName)
        {
            this.serializationFileName = serializationFileName;
        }

        public void Serialize()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            options.Converters.Add(new JsonStringEnumConverter());

            string jsonString = JsonSerializer.Serialize(GlobalSettings.Instance, options);
            File.WriteAllText(serializationFileName, jsonString);
        }

        public void Deserialize()
        {
            string jsonString = File.ReadAllText(serializationFileName);

            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            JsonElement root = jsonDocument.RootElement;


            GlobalSettings.Instance.Discount = GetDoubleFromJsonElement("Discount", root);
            GlobalSettings.Instance.Tax = GetDoubleFromJsonElement("Tax", root);
            GlobalSettings.Instance.Currency = GetEnumFromJsonElement<Currency>("Currency", root);
            GlobalSettings.Instance.DiscountType = GetEnumFromJsonElement<DiscountType>("DiscountType", root);

            JsonElement discountLimit = root.GetProperty("DiscountLimit");

            GlobalSettings.Instance.DiscountLimit.DiscountLimitPercentage = GetDoubleFromJsonElement("DiscountLimitPercentage", discountLimit);
            GlobalSettings.Instance.DiscountLimit.DiscountLimitFixedAmount = GetDoubleFromJsonElement("DiscountLimitFixedAmount", discountLimit);

        }

        private double GetDoubleFromJsonElement(string propertyName, JsonElement jsonElement)
        {
            if (jsonElement.GetProperty(propertyName).TryGetDouble(out double value))
                return value;
            return 0;
        }

        private T GetEnumFromJsonElement<T>(string enumName, JsonElement jsonElement) where T : struct
        {
            if (Enum.TryParse<T>(jsonElement.GetProperty(enumName).ToString(), out T enumValue))
                return enumValue;
            return default(T);
        }

    }
}
