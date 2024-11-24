namespace BookingTour.App.Helper
{
    public static class DatabaseSeeder
    {
        private static DatabaseHelper _dbHelper = DatabaseHelper.Instance;

        public static void Seed()
        {
            _dbHelper.OpenConnection();
            _dbHelper.BeginTransaction();

            try
            {
                // check if the database is already seeded
                var checkQuery = "SELECT COUNT(*) FROM role";
                var roleCount = Convert.ToInt32(_dbHelper.ExecuteScalar(checkQuery));
                if (roleCount > 0)
                {
                    _dbHelper.CloseConnection();
                    return;
                }

                // seed role
                var insertQuery = @"
                INSERT INTO role (id, name) VALUES
                (1, 'ADMIN'),
                (2, 'STAFF'),
                (3, 'TOUR_GUIDE')";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed user
                insertQuery = @"
                INSERT INTO user (id, username, password, name, email, phone_number, is_block, role_id) VALUES
                (1, 'admin', 'admin', 'Admin', 'admin@gmail.com', '0123456789', 0, 1),
                (2, 'staff', 'staff', 'Staff', 'staff@gmail.com', '0123456789', 0, 2),
                (3, 'guid1', 'guide1', 'Guide 1', 'guide1@gmail.com', '0123456789', 0, 3),
                (4, 'guid2', 'guid2', 'Guide 2', 'guide2@gmail.com', '0123456789', 0, 3),
                (5, 'guid3', 'guide3', 'Guide 3', 'guide3@gmail.com', '0123456789', 0, 3),
                (6, 'guid4', 'guide4', 'Guide 4', 'guide4@gmail.com', '0123456789', 0, 3),
                (7, 'guid5', 'guide5', 'Guide 5', 'guide5@gmail.com', '0123456789', 0, 3),
                (8, 'guid6', 'guide6', 'Guide 6', 'guide6@gmail.com', '0123456789', 0, 3),
                (9, 'guid7', 'guide7', 'Guide 7', 'guide7@gmail.com', '0123456789', 0, 3),
                (10, 'guid8', 'guide8', 'Guide 8', 'guide8@gmail.com', '0123456789', 0, 3)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed guides
                insertQuery = @"
                INSERT INTO guides (id, language, account_id) VALUES
                (1, 'Vietnamese', 3),
                (2, 'English', 4),
                (3, 'Chinese', 5),
                (4, 'Vietnamese', 6),
                (5, 'English', 7),
                (6, 'Vietnamese', 8)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed places
                insertQuery = @"
                INSERT INTO place (id, name) VALUES
                (1, 'Place A'),
                (2, 'Place B'),
                (3, 'Place C'),
                (4, 'Place D'),
                (5, 'Place E'),
                (6, 'Place F'),
                (7, 'Place G'),
                (8, 'Place H'),
                (9, 'Place I'),
                (10, 'Place K')";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed activities
                insertQuery = @"
                INSERT INTO activity (id, name, description, place_id) VALUES
                (1, 'Activity 1', 'Something', 1),
                (2, 'Activity 2', 'Something', 2),
                (3, 'Activity 3', 'Something', 3),
                (4, 'Activity 4', 'Something', 4),
                (5, 'Activity 5', 'Something', 5),
                (6, 'Activity 6', 'Something', 6),
                (7, 'Activity 7', 'Something', 7),
                (8, 'Activity 8', 'Something', 8),
                (9, 'Activity 9', 'Something', 9),
                (10, 'Activity 10', 'Something', 10)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed services
                insertQuery = @"
                INSERT INTO service (id, name, type, description) VALUES
                (1, 'Service 1', 'Type 1', 'Something'),
                (2, 'Service 2', 'Type 2', 'Something'),
                (3, 'Service 3', 'Type 3', 'Something'),
                (4, 'Service 4', 'Type 4', 'Something'),
                (5, 'Service 5', 'Type 5', 'Something'),
                (6, 'Service 6', 'Type 6', 'Something'),
                (7, 'Service 7', 'Type 7', 'Something'),
                (8, 'Service 8', 'Type 8', 'Something'),
                (9, 'Service 9', 'Type 9', 'Something'),
                (10, 'Service 10', 'Type 10', 'Something')";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed itinerary
                insertQuery = @"
                INSERT INTO itinerary (id, name, number_of_days, vehicle, description, capacity) VALUES
                (1, 'Du lịch Đà Nẵng', 7, 'Máy bay', 'Something', 20),
                (2, 'Du lịch Nha Trang', 7, 'Ô tô', 'Something', 30),
                (3, 'Du lịch Đà Lạt', 4, 'Tàu hỏa', 'Something', 20),
                (4, 'Du lịch Vũng Tàu', 3, 'Xe máy', 'Something', 20),
                (5, 'Du lịch Cà Màu', 10, 'Xe đạp', 'Something', 50)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed itinerary details
                insertQuery = @"
                INSERT INTO itinerary_detail (tour_interface_id, activity_id, service_id, day_number, start_time, end_time) VALUES
                (1, 1, 1, 1, '08:00:00', '10:00:00'),
                (1, 2, 2, 1, '10:00:00', '12:00:00'),
                (1, 3, 3, 1, '14:00:00', '16:00:00'),
                (1, 4, 4, 2, '08:00:00', '10:00:00'),
                (1, 5, 5, 2, '10:00:00', '12:00:00'),
                (1, 6, 6, 2, '14:00:00', '16:00:00'),
                (1, 7, 7, 3, '08:00:00', '10:00:00'),
                (1, 8, 8, 3, '10:00:00', '12:00:00'),
                (1, 9, 9, 3, '14:00:00', '16:00:00'),
                ( 1, 10, 10, 4, '08:00:00', '10:00:00'),
                ( 2, 1, 1, 4, '10:00:00', '12:00:00'),
                ( 2, 2, 2, 4, '14:00:00', '16:00:00'),
                ( 2, 3, 3, 5, '08:00:00', '10:00:00'),
                ( 2, 4, 4, 5, '10:00:00', '12:00:00'),
                ( 2, 5, 5, 5, '14:00:00', '16:00:00'),
                ( 2, 6, 6, 6, '08:00:00', '10:00:00'),
                ( 2, 7, 7, 6, '10:00:00', '12:00:00'),
                ( 2, 8, 8, 6, '14:00:00', '16:00:00'),
                ( 2, 9, 9, 7, '08:00:00', '10:00:00'),
                (2, 10, 10, 7, '10:00:00', '12:00:00')";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed tour
                insertQuery = @"
                INSERT INTO tour (id, date_start, date_end, itinerary_id, price, capacity, remaining_slots) VALUES
                (1, '2022-12-01', '2022-12-07', 1, 10000000, 20, 20),
                (2, '2022-12-01', '2022-12-07', 2, 10000000, 30, 30),
                (3, '2022-12-01', '2022-12-04', 3, 5000000, 20, 20),
                (4, '2022-12-01', '2022-12-03', 4, 3000000, 20, 20),
                (5, '2022-12-01', '2022-12-10', 5, 15000000, 50, 50)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed tour guides
                insertQuery = @"
                INSERT INTO tour_guides (tour_id, guide_id) VALUES
                (1, 1),
                (1, 2),
                (1, 3),
                (2, 4),
                (2, 5),
                (2, 6)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed passengers
                insertQuery = @"
                INSERT INTO passenger (id, name, email, phone_number, age) VALUES
                (1, 'Passenger 1', 'p1@gmail.com', '0123456789', 20), 
                (2, 'Passenger 2', 'p2@gmail.com', '0123456789', 21),
                (3, 'Passenger 3', 'p3@gmail.com', '0123456789', 22),
                (4, 'Passenger 4', 'p4@gmail.com', '0123456789', 23),
                (5, 'Passenger 5', 'p5@gmail.com', '0123456789', 24),
                (6, 'Passenger 6', 'p6@gmail.com', '0123456789', 25),
                (7, 'Passenger 7', 'p7@gmail.com', '0123456789', 26),
                (8, 'Passenger 8', 'p8@gmail.com', '0123456789', 27),
                (9, 'Passenger 9', 'p9@gmail.com', '0123456789', 28),
                (10, 'Passenger 10', 'p10@gmail.com', '0123456789', 29)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed bill
                insertQuery = @"
                INSERT INTO bill (id, total_passenger, total_price, invoice_issuer) VALUES
                (1, 2, 20000000, 1),
                (2, 2, 30000000, 2)";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // seed ticket
                insertQuery = @"
                INSERT INTO ticket (id, tour_id, passenger_id, bill_id, price, type) VALUES
                (1, 1, 1, 1, 10000000, 'adult'),
                (2, 1, 2, 1, 10000000, 'adult'),
                (3, 5, 3, 2, 15000000, 'adult'),
                (4, 5, 4, 2, 15000000, 'adult')";

                _dbHelper.ExecuteNonQuery(insertQuery);

                // commit
                _dbHelper.CommitTransaction();
            }
            catch (System.Exception ex)
            {
                // rollback 
                _dbHelper.RollbackTransaction();
                throw;
            }
            finally
            {
                _dbHelper.CloseConnection();
            }
        }
    }
}