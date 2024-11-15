using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;

namespace task2_design_patterns.Services
{
    public class PromotionService
    {
        private readonly DatabaseHelper DbHelper;

        public PromotionService()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }

        public int CreatePromotion(CreatePromotionDto promotionDto)
        {
            var promotionTable = DbHelper.GetTable("Promotion");

            var newRow = promotionTable.NewRow();
            newRow["name"] = promotionDto.Name;
            newRow["initdate"] = promotionDto.InitDate.ToString();
            newRow["enddate"] = promotionDto.EndDate.ToString();
            newRow["discount"] = promotionDto.Discount;
            newRow["state"] = promotionDto.State;
            promotionTable.Rows.Add(newRow);
            return (int)newRow["id"];
        }
    }
}
