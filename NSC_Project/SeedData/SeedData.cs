using Microsoft.EntityFrameworkCore;
using NSC_Project.Data;
using NSC_Project.Models;

namespace NSC_Project.SeedData
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

				context.Role.AddRange(
					new Role
					{
						//Id = 1
						RoleName = "Admin",
						Description = "Full quyền"
					},
					new Role
					{
						//Id = 2
						RoleName = "Sales Agent",
						Description = "Đại lý bán vé"
					},
					new Role
					{
						//Id = 2
						RoleName = "Client",
						Description = "Người dùng"
					}

				);
				context.SaveChanges();

				context.User.AddRange(
					new User
					{
						RoleId = 1,
						UserName = "Admin",
						Email = "admin@gmail.com",
						Password = BCrypt.Net.BCrypt.HashPassword("123456")
					},
					new User
					{
						RoleId = 3,
						UserName = "Dũng Nguyễn",
						Email = "dungtrapboy@gmail.com",
						Password = BCrypt.Net.BCrypt.HashPassword("123456")
					}
				);
				context.SaveChanges();


				context.AirportFrom.AddRange(
					new AirportFrom
					{
						Name = "VNA-001",
						Address = "Hồ Chí Minh (SGN)-Sân Bay Tân Sơn Nhất",
					},
					new AirportFrom
					{
						Name = "VNA-002",
						Address = "Hà Nội(HAN)-Sân Bay Nội Bài",
					},
					new AirportFrom
					{
						Name = "VNA-003",
						Address = "Nha Trang(CXR)-Sân Bay Cam Ranh",
					},
					new AirportFrom
					{
						Name = "VNA-004",
						Address = "Phú Quốc(PQC)-Sân Bay Phú Quốc",
					},
					new AirportFrom
					{
						Name = "VNA-005",
						Address = "Quảng Nam(VCL)-Sân Bay Chu Lai",
					},
					new AirportFrom
					{
						Name = "VNA-006",
						Address = "Cần Thơ(VCA)-Sân Bay Cần Thơ",
					},
					new AirportFrom
					{
						Name = "VNA-007",
						Address = "Hải Phòng(HPH)-Sân Bay Cát Bi",
					},
					new AirportFrom
					{
						Name = "VNA-008",
						Address = "QUảng Ninh(VDO)-Sân Bay Vân Đồn",
					},
					new AirportFrom
					{
						Name = "VNA-009",
						Address = "Vinh(VII)-Sân Bay Vinh",
					},
					new AirportFrom
					{

						Name = "VNA-010",
						Address = "Tuy Hoà(TBB)-Sân Bay Tuy Hoà",
					},
					new AirportFrom
					{

						Name = "VNA-011",
						Address = "Chiang Mai(CNX)-Sân Bay Quốc Tế Chiang Mai",
					},
					new AirportFrom
					{

						Name = "VNA-012",
						Address = "Ko Samui(USM)-Sân Bay Samui",
					},
					new AirportFrom
					{

						Name = "VNA-013",
						Address = "Udon Thani(UTH)-Sân Bay Udon Thani",
					},
					new AirportFrom
					{

						Name = "VNA-014",
						Address = "Krabi(KBV)-Sân Bay Krabi",
					},
					new AirportFrom
					{

						Name = "VNA-015",
						Address = "Udon Ratchathani(UBP)-Sân Bay Udon Ratchathani",
					},
					new AirportFrom
					{

						Name = "VNA-016",
						Address = "Buri Ram(BFV)-Sân Bay Buri Ram",
					},
					new AirportFrom
					{

						Name = "VNA-017",
						Address = "Bangkok(BKK)-Sân Bay Suvarnabhumi",
					},
					new AirportFrom
					{

						Name = "VNA-018",
						Address = "Singapore(SIN)-Sân Bay Singapore Changi",
					},
					new AirportFrom
					{

						Name = "VNA-019",
						Address = "Pattaya(UTP)-Sân Bay Quốc tế U-Tapao",
					},
					new AirportFrom
					{

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
						Name = "VNA-001",
						Address = "Hồ Chí Minh (SGN)-Sân Bay Tân Sơn Nhất",
					},
					new AirportTo
					{
						Name = "VNA-002",
						Address = "Hà Nội(HAN)-Sân Bay Nội Bài",
					},
					new AirportTo
					{
						Name = "VNA-003",
						Address = "Nha Trang(CXR)-Sân Bay Cam Ranh",
					},
					new AirportTo
					{
						Name = "VNA-004",
						Address = "Phú Quốc(PQC)-Sân Bay Phú Quốc",
					},
					new AirportTo
					{
						Name = "VNA-005",
						Address = "Quảng Nam(VCL)-Sân Bay Chu Lai",
					},
					new AirportTo
					{
						Name = "VNA-006",
						Address = "Cần Thơ(VCA)-Sân Bay Cần Thơ",
					},
					new AirportTo
					{
						Name = "VNA-007",
						Address = "Hải Phòng(HPH)-Sân Bay Cát Bi",
					},
					new AirportTo
					{
						Name = "VNA-008",
						Address = "QUảng Ninh(VDO)-Sân Bay Vân Đồn",
					},
					new AirportTo
					{
						Name = "VNA-009",
						Address = "Vinh(VII)-Sân Bay Vinh",
					},
					new AirportTo
					{

						Name = "VNA-010",
						Address = "Tuy Hoà(TBB)-Sân Bay Tuy Hoà",
					},
					new AirportTo
					{

						Name = "VNA-011",
						Address = "Chiang Mai(CNX)-Sân Bay Quốc Tế Chiang Mai",
					},
					new AirportTo
					{

						Name = "VNA-012",
						Address = "Ko Samui(USM)-Sân Bay Samui",
					},
					new AirportTo
					{

						Name = "VNA-013",
						Address = "Udon Thani(UTH)-Sân Bay Udon Thani",
					},
					new AirportTo
					{

						Name = "VNA-014",
						Address = "Krabi(KBV)-Sân Bay Krabi",
					},
					new AirportTo
					{

						Name = "VNA-015",
						Address = "Udon Ratchathani(UBP)-Sân Bay Udon Ratchathani",
					},
					new AirportTo
					{

						Name = "VNA-016",
						Address = "Buri Ram(BFV)-Sân Bay Buri Ram",
					},
					new AirportTo
					{

						Name = "VNA-017",
						Address = "Bangkok(BKK)-Sân Bay Suvarnabhumi",
					},
					new AirportTo
					{

						Name = "VNA-018",
						Address = "Singapore(SIN)-Sân Bay Singapore Changi",
					},
					new AirportTo
					{

						Name = "VNA-019",
						Address = "Pattaya(UTP)-Sân Bay Quốc tế U-Tapao",
					},
					new AirportTo
					{

						Name = "VNA-020",
						Address = "Phuket(HKT)-Sân Bay Quốc Tế Phuket",
					}
					);
				context.SaveChanges();

				context.AirlineCompany.AddRange(
					new AirlineCompany
					{
						Name = "Vietjet Air",
						Logo = "Vietjet.jpg"
					},
					new AirlineCompany
					{
						Name = "Vietnam Airlines",
						Logo = "Airlines.jpg"
					},
					new AirlineCompany
					{
						Name = "Bamboo Airways",
						Logo = "Bambo.jpg"
					}
				);
				context.SaveChanges();



				context.Plane.AddRange(
						new Plane
						{
							Name = "Boeing 787"
						},
						new Plane
						{
							Name = "Airbus A350"
						},
						new Plane
						{
							Name = "Airbus A330"
						},
						new Plane
						{
							Name = "Airbus A321"
						},
						new Plane
						{
							Name = "Boeing 737 MAX 200"
						},
						new Plane
						{
							Name = "Airbus A321"
						},
						new Plane
						{
							Name = "Airbus A321 neo"
						}
					);
				context.SaveChanges();

				context.FlightRoute.AddRange(
						new FlightRoute
						{
							AirportFromId = 1,
							AirportToId = 2,
						}
					);
				context.SaveChanges();

				context.Trip.AddRange(
						new Trip
						{
							StartDate = new DateTime(2022, 12, 31, 5, 30, 0),
							FinishDate = new DateTime(2022, 12, 31, 7, 30, 0),
							FlightTime = 2,
							Status = 0,
							PlaneId = 1,
							FlightRouteId = 1,
							AirlineCompanyId = 1
						}
					);
				context.SaveChanges();

				context.TicketClass.AddRange(
						new TicketClass
						{
							Name = "Eco"
						},
						new TicketClass
						{
							Name = "Economy Saver"
						},
						new TicketClass
						{
							Name = "Deluxe"
						},
						new TicketClass
						{
							Name = "SkyBoss"
						}
					);
				context.SaveChanges();

				context.Fare.AddRange(
						new Fare
						{
							Qty = 50,
							Price = 3500000,
							TripId= 1,
							TicketClassId= 1
						},
						 new Fare
						 {
							 Qty = 50,
							 Price = 8650000,
							 TripId = 1,
							 TicketClassId = 2
						 },
						  new Fare
						  {
							  Qty = 50,
							  Price = 10640000,
							  TripId = 1,
							  TicketClassId = 3
						  },
						   new Fare
						   {
							   Qty = 50,
							   Price = 15550000,
							   TripId = 1,
							   TicketClassId = 4
						   }
					);
				context.SaveChanges();

				context.Ticket.AddRange(
						new Ticket
						{
							FareId= 1,
							TripId= 1
						},
						new Ticket
						{
							FareId = 2,
							TripId = 1
						},
						new Ticket
						{
							FareId = 3,
							TripId = 1
						},
						new Ticket
						{
							FareId = 4,
							TripId = 1
						}
					);
				context.SaveChanges();
			}
		}
	}
}
