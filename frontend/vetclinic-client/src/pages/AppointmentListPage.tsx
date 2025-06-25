import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import {
  getAllAppointments,
  deleteAppointment,
  AppointmentDto
} from '../api/vetClinicApi';

const AppointmentsListPage: React.FC = () => {
  const [appointments, setAppointments] = useState<AppointmentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getAllAppointments()
      .then(response => setAppointments(response.data))
      .catch(err => setError(err.message))
      .finally(() => setLoading(false));
  }, []);

  const handleDelete = async (id: number) => {
    if (window.confirm('Czy na pewno chcesz usunąć tę wizytę?')) {
      try {
        await deleteAppointment(id);
        setAppointments(prev => prev.filter(a => a.id !== id));
      } catch (err) {
        console.error(err);
        alert('Wystąpił błąd podczas usuwania.');
      }
    }
  };

  if (loading) {
    return <div>Ładowanie wizyt...</div>;
  }

  if (error) {
    return <div>Błąd: {error}</div>;
  }

  return (
    <div style={{ padding: '1rem' }}>
      <h1>Wizyty</h1>
      <Link to="/appointments/new" style={{ marginBottom: '1rem', display: 'inline-block' }}>
        Dodaj nową wizytę
      </Link>
      {appointments.length === 0 ? (
        <p>Brak wizyt w bazie.</p>
      ) : (
        <table style={{ width: '100%', borderCollapse: 'collapse' }}>
          <thead>
            <tr>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>ID</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Data</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Cel</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Zwierzę ID</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Weterynarz ID</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Procedury</th>
              <th style={{ border: '1px solid #ccc', padding: '0.5rem' }}>Akcje</th>
            </tr>
          </thead>
          <tbody>
            {appointments.map(appointment => (
              <tr key={appointment.id}>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{appointment.id}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  {new Date(appointment.date).toLocaleString()}
                </td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{appointment.purpose}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  <Link to={`/animals/${appointment.animalId}`}>
                    {appointment.animalId}
                  </Link>
                </td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  <Link to={`/veterinarians/${appointment.vetId}`}>
                    {appointment.vetId}
                  </Link>
                </td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  {appointment.procedureIds.join(', ')}
                </td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  <Link to={`/appointments/${appointment.id}/edit`} style={{ marginRight: '0.5rem' }}>
                    Edytuj
                  </Link>
                  <button onClick={() => handleDelete(appointment.id)}>
                    Usuń
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default AppointmentsListPage;