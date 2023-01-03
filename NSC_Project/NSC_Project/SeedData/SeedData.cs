using Microsoft.EntityFrameworkCore;
using NSC_Project.Data;
using NSC_Project.Models;

namespace NSC_Project.Seeding
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NSC_ProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<NSC_ProjectContext>>()))
            {
                if (context.AirportFrom.Any())
                {
                    return;
                }
                context.AirportFrom.AddRange(
                    new AirportFrom
                    {
                        Id = 1,
                        Name = "VNA-001",
                        Address = "Hồ Chí Minh (SGN)-Sân Bay Tân Sơn Nhất",
                    },
                    new AirportFrom
                    {
                        Id = 2,
                        Name = "VNA-002",
                        Address = "Hà Nội(HAN)-Sân Bay Nội Bài",
                    },
                    new AirportFrom
                    {
                        Id = 3,
                        Name = "VNA-003",
                        Address = "Nha Trang(CXR)-Sân Bay Cam Ranh",
                    },
                    new AirportFrom
                    {
                        Id = 4,
                        Name = "VNA-004",
                        Address = "Phú Quốc(PQC)-Sân Bay Phú Quốc",
                    },
                    new AirportFrom
                    {
                        Id = 5,
                        Name = "VNA-005",
                        Address = "Quảng Nam(VCL)-Sân Bay Chu Lai",
                    },
                    new AirportFrom
                    {
                        Id = 6,
                        Name = "VNA-006",
                        Address = "Cần Thơ(VCA)-Sân Bay Cần Thơ",
                    },
                    new AirportFrom
                    {
                        Id = 7,
                        Name = "VNA-007",
                        Address = "Hải Phòng(HPH)-Sân Bay Cát Bi",
                    },
                    new AirportFrom
                    {
                        Id = 8,
                        Name = "VNA-008",
                        Address = "QUảng Ninh(VDO)-Sân Bay Vân Đồn",
                    },
                    new AirportFrom
                    {
                        Id = 9,
                        Name = "VNA-009",
                        Address = "Vinh(VII)-Sân Bay Vinh",
                    },
                    new AirportFrom
                    {
                        Id = 10,
                        Name = "VNA-010",
                        Address = "Tuy Hoà(TBB)-Sân Bay Tuy Hoà",
                    },
                    new AirportFrom
                    {
                        Id = 11,
                        Name = "VNA-011",
                        Address = "Chiang Mai(CNX)-Sân Bay Quốc Tế Chiang Mai",
                    },
                    new AirportFrom
                    {
                        Id = 12,
                        Name = "VNA-012",
                        Address = "Ko Samui(USM)-Sân Bay Samui",
                    },
                    new AirportFrom
                    {
                        Id = 13,
                        Name = "VNA-013",
                        Address = "Udon Thani(UTH)-Sân Bay Udon Thani",
                    },
                    new AirportFrom
                    {
                        Id = 14,
                        Name = "VNA-014",
                        Address = "Krabi(KBV)-Sân Bay Krabi",
                    },
                    new AirportFrom
                    {
                        Id = 15,
                        Name = "VNA-015",
                        Address = "Udon Ratchathani(UBP)-Sân Bay Udon Ratchathani",
                    },
                    new AirportFrom
                    {
                        Id = 16,
                        Name = "VNA-016",
                        Address = "Buri Ram(BFV)-Sân Bay Buri Ram",
                    },
                    new AirportFrom
                    {
                        Id = 17,
                        Name = "VNA-017",
                        Address = "Bangkok(BKK)-Sân Bay Suvarnabhumi",
                    },
                    new AirportFrom
                    {
                        Id = 18,
                        Name = "VNA-018",
                        Address = "Singapore(SIN)-Sân Bay Singapore Changi",
                    },
                    new AirportFrom
                    {
                        Id = 19,
                        Name = "VNA-019",
                        Address = "Pattaya(UTP)-Sân Bay Quốc tế U-Tapao",
                    },
                    new AirportFrom
                    {
                        Id = 20,
                        Name = "VNA-020",
                        Address = "Phuket(HKT)-Sân Bay Quốc Tế Phuket",
                    }
                    );
                context.SaveChanges();

                if (context.AirportTo.Any())
                {
                    return;
                }
                context.AirportTo.AddRange(
                    new AirportTo
                    {
                        Id = 1,
                        Name = "VNA-001",
                        Address = "Chiang Mai(CNX)-Sân Bay Quốc Tế Chiang Mai",
                    },
                    new AirportTo
                    {
                        Id = 2,
                        Name = "VNA-002",
                        Address = "Ko Samui(USM)-Sân Bay Samui",
                    },
                    new AirportTo
                    {
                        Id = 3,
                        Name = "VNA-003",
                        Address = "Udon Thani(UTH)-Sân Bay Udon Thani",
                    },
                    new AirportTo
                    {
                        Id = 4,
                        Name = "VNA-004",
                        Address = "Krabi(KBV)-Sân Bay Krabi",
                    },
                    new AirportTo
                    {
                        Id = 5,
                        Name = "VNA-005",
                        Address = "QUdon Ratchathani(UBP)-Sân Bay Udon Ratchathani",
                    },
                    new AirportTo
                    {
                        Id = 6,
                        Name = "VNA-006",
                        Address = "Buri Ram(BFV)-Sân Bay Buri Ram",
                    },
                    new AirportTo
                    {
                        Id = 7,
                        Name = "VNA-007",
                        Address = "HBangkok(BKK)-Sân Bay Suvarnabhumi",
                    },
                    new AirportTo
                    {
                        Id = 8,
                        Name = "VNA-008",
                        Address = "QSingapore(SIN)-Sân Bay Singapore Changi",
                    },
                    new AirportTo
                    {
                        Id = 9,
                        Name = "VNA-009",
                        Address = "VPattaya(UTP)-Sân Bay Quốc tế U-Tapao",
                    },
                    new AirportTo
                    {
                        Id = 10,
                        Name = "VNA-010",
                        Address = "Phuket(HKT)-Sân Bay Quốc Tế Phuket",
                    },
                    new AirportTo
                    {
                        Id = 11,
                        Name = "VNA-011",
                        Address = "Hồ Chí Minh (SGN)-Sân Bay Tân Sơn Nhất",
                    },
                    new AirportTo
                    {
                        Id = 12,
                        Name = "VNA-012",
                        Address = "Hà Nội(HAN)-Sân Bay Nội Bài",
                    },
                    new AirportTo
                    {
                        Id = 13,
                        Name = "VNA-013",
                        Address = "UNha Trang(CXR)-Sân Bay Cam Ranh",
                    },
                    new AirportTo
                    {
                        Id = 14,
                        Name = "VNA-014",
                        Address = "Phú Quốc(PQC)-Sân Bay Phú Quốc",
                    },
                    new AirportTo
                    {
                        Id = 15,
                        Name = "VNA-015",
                        Address = "Quảng Nam(VCL)-Sân Bay Chu Lai",
                    },
                    new AirportTo
                    {
                        Id = 16,
                        Name = "VNA-016",
                        Address = "Cần Thơ(VCA)-Sân Bay Cần Thơ",
                    },
                    new AirportTo
                    {
                        Id = 17,
                        Name = "VNA-017",
                        Address = "Hải Phòng(HPH)-Sân Bay Cát Bi",
                    },
                    new AirportTo
                    {
                        Id = 18,
                        Name = "VNA-018",
                        Address = "QUảng Ninh(VDO)-Sân Bay Vân Đồn",
                    },
                    new AirportTo
                    {
                        Id = 19,
                        Name = "VNA-019",
                        Address = "Vinh(VII)-Sân Bay Vinh",
                    },
                    new AirportTo
                    {
                        Id = 20,
                        Name = "VNA-020",
                        Address = "Tuy Hoà(TBB)-Sân Bay Tuy Hoà",
                    }
                    );
                context.SaveChanges();

                context.AddRange(
                    new AirlineCompany
                    {
                        Name = "Vietjet Air",
                        Logo = ""
                    },
                    new AirlineCompany
                    {
                        Name = "Vietnam Airlines",
                        Logo = ""
                    },
                    new AirlineCompany
                    {
                        Name = "Bamboo Airways",
                        Logo = ""
                    }
                );
            }
        }
    }
}
