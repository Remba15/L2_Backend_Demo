using Microsoft.Data.SqlClient;
using Project.Service.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        string _connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VehicleProject; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
        public async void DeleteMake(VehicleMake vehicleMake)
        {
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "DELETE FROM dbo.VehicleMakes WHERE Id = @Id, Name = @Name, Abbreviation = @Abbreviation";

                using(SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleMake.Id);
                    _command.Parameters.AddWithValue("@Name", vehicleMake.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleMake.Abbreviation);

                    _connection.Open();
                }
            }
        }

        public async void DeleteModel(VehicleModel vehicleModel)
        {
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "DELETE FROM dbo.VehicleModels WHERE Id = @Id, MakeId = @MakeId, Name = @Name, Abbreviation = @Abbreviation";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleModel.Id);
                    _command.Parameters.AddWithValue("@MakeId", vehicleModel.MakeId);
                    _command.Parameters.AddWithValue("@Name", vehicleModel.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleModel.Abbreviation);

                    _connection.Open();
                }
            }
        }

        public async Task<List<VehicleMake>> GetMakes()
        {
            List<VehicleMake> _makeList = new List<VehicleMake>();
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "SELECT * FROM dbo.VehicleMakes";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _connection.Open();
                    using(SqlDataReader _reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                VehicleMake _vehicleMake = new VehicleMake();
                                _vehicleMake.Id = _reader.GetInt32(_reader.GetOrdinal("Id"));
                                _vehicleMake.Name = _reader.GetString(_reader.GetOrdinal("Name"));
                                _vehicleMake.Abbreviation = _reader.GetString(_reader.GetOrdinal("Abbreviation"));
                                _makeList.Add(_vehicleMake);
                            }
                        }
                    }
                }
            }
            return _makeList;
            
        }

        public async Task<List<VehicleModel>> GetModels()
        {

            List<VehicleModel> _modelList = new List<VehicleModel>();
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "SELECT * FROM dbo.VehicleModels";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _connection.Open();
                    await using (SqlDataReader _reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                VehicleModel _vehicleModel = new VehicleModel();
                                _vehicleModel.Id = _reader.GetInt32(_reader.GetOrdinal("Id"));
                                _vehicleModel.MakeId = _reader.GetInt32(_reader.GetOrdinal("MakeId"));
                                _vehicleModel.Name = _reader.GetString(_reader.GetOrdinal("Name"));
                                _vehicleModel.Abbreviation = _reader.GetString(_reader.GetOrdinal("Abbreviation"));
                                _modelList.Add(_vehicleModel);
                            }
                        }
                    }
                }
            }
            return _modelList;
        }

        public async Task<VehicleMake> GetMakeById(int id)
        {
            VehicleMake _vehicleMake = new VehicleMake();
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "SELECT * FROM dbo.VehicleMakes WHERE Id = @Id";

                await using(SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);

                    _connection.Open();
                    await using(SqlDataReader _reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                _vehicleMake.Id = _reader.GetInt32(_reader.GetOrdinal("Id"));
                                _vehicleMake.Name = _reader.GetString(_reader.GetOrdinal("Name"));
                                _vehicleMake.Abbreviation = _reader.GetString(_reader.GetOrdinal("Abbreviation"));
                            }
                        }
                    }
                }
            }
            return _vehicleMake;
        }

        public async Task<VehicleModel> GetModelById(int id)
        {
            VehicleModel _vehicleModel = new VehicleModel();
            await using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "SELECT * FROM dbo.VehicleModels WHERE Id = @Id";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);

                    _connection.Open();
                    await using (SqlDataReader _reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                _vehicleModel.Id = _reader.GetInt32(_reader.GetOrdinal("Id"));
                                _vehicleModel.MakeId = _reader.GetInt32(_reader.GetOrdinal("MakeId"));
                                _vehicleModel.Name = _reader.GetString(_reader.GetOrdinal("Name"));
                                _vehicleModel.Abbreviation = _reader.GetString(_reader.GetOrdinal("Abbreviation"));
                            }
                        }
                    }
                }
            }
            return _vehicleModel;

        }

        public async void InsertMake(VehicleMake vehicleMake)
        {

            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "INSERT INTO dbo.VehicleMakes (Id, Name, Abbreviation) VALUES (@Id, @Name, @Abbreviation)";

                await using(SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleMake.Id);
                    _command.Parameters.AddWithValue("@Name", vehicleMake.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleMake.Abbreviation);

                    _connection.Open();
                }
            }

        }


        public async void InsertModel(VehicleModel vehicleModel)
        {
            await using(SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "INSERT INTO dbo.VehicleModels (Id, MakeId, Name, Abbreviation) VALUES (@Id, @MakeId, @Name, @Abbreviation)";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleModel.Id);
                    _command.Parameters.AddWithValue("@MakeId", vehicleModel.MakeId);
                    _command.Parameters.AddWithValue("@Name", vehicleModel.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleModel.Abbreviation);

                    _connection.Open();
                }
            }
        }

        public async void UpdateMake(VehicleMake vehicleMake)
        {
            await using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "UPDATE dbo.VehicleMakes SET Id = @Id, Name = @Name, Abbreviation = @Abbreviation";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleMake.Id);
                    _command.Parameters.AddWithValue("@Name", vehicleMake.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleMake.Abbreviation);

                    _connection.Open();
                }
            }
        }

        public async void UpdateModel(VehicleModel vehicleModel)
        {
            await using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string _query = "UPDATE dbo.VehicleModels SET Id = @Id, MakeId = @MakeId, Name = @Name, Abbreviation = @Abbreviation";

                await using (SqlCommand _command = new SqlCommand(_query, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", vehicleModel.Id);
                    _command.Parameters.AddWithValue("@MakeId", vehicleModel.MakeId);
                    _command.Parameters.AddWithValue("@Name", vehicleModel.Name);
                    _command.Parameters.AddWithValue("@Abbreviation", vehicleModel.Abbreviation);

                    _connection.Open();
                }
            }
        }
    }
}
