import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import {
  getAllAnimals,
  deleteAnimal,
  AnimalDto
} from '../api/vetClinicApi';

const AnimalsListPage: React.FC = () => {
  const [animals, setAnimals] = useState<AnimalDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getAllAnimals()
      .then(response => setAnimals(response.data))
      .catch(err => setError(err.message))
      .finally(() => setLoading(false));
  }, []);

  const handleDelete = async (id: number) => {
    if (window.confirm('Czy na pewno chcesz usunąć to zwierzę?')) {
      try {
        await deleteAnimal(id);
        setAnimals(prev => prev.filter(a => a.id !== id));
      } catch {
        alert('Wystąpił błąd podczas usuwania.');
      }
    }
  };

  if (loading) return <div>Ładowanie...</div>;
  if (error)   return <div>Błąd: {error}</div>;

  return (
    <div style={{ padding: '1rem' }}>
      <h1>Zwierzęta</h1>
      <Link to="/animals/new" style={{ marginBottom: '1rem', display: 'inline-block' }}>
        Dodaj nowe zwierzę
      </Link>

      {animals.length === 0 ? (
        <p>Brak zwierząt w bazie.</p>
      ) : (
        <table style={{ width: '100%', borderCollapse: 'collapse' }}>
          <thead>
            <tr>
              {['ID','Imię','Gatunek','Wiek','Rasa','Owner ID','Akcje'].map(header => (
                <th key={header} style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  {header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {animals.map(animal => (
              <tr key={animal.id}>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{animal.id}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  <Link to={`/animals/${animal.id}`}>{animal.name}</Link>
                </td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{animal.species}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{animal.age}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{animal.breed}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>{animal.ownerId}</td>
                <td style={{ border: '1px solid #ccc', padding: '0.5rem' }}>
                  <Link to={`/animals/${animal.id}/edit`} style={{ marginRight: '0.5rem' }}>
                    Edytuj
                  </Link>
                  <button onClick={() => handleDelete(animal.id)}>
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

export default AnimalsListPage;