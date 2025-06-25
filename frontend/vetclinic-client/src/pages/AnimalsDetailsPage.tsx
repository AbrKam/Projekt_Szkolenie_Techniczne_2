import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import {
  getAnimalById,
  AnimalDto
} from '../api/vetClinicApi';

const AnimalDetailsPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [animal, setAnimal] = useState<AnimalDto | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) {
      setError('Brak ID zwierzęcia w ścieżce.');
      setLoading(false);
      return;
    }
    getAnimalById(Number(id))
      .then(response => {
        setAnimal(response.data);
        setError(null);
      })
      .catch(err => {
        setError(err.message);
      })
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <div>Ładowanie szczegółów...</div>;
  if (error)   return <div>Błąd: {error}</div>;
  if (!animal) return <div>Nie znaleziono zwierzęcia.</div>;

  return (
    <div style={{ padding: '1rem' }}>
      <h1>Szczegóły zwierzęcia: {animal.name}</h1>
      <p><strong>ID:</strong> {animal.id}</p>
      <p><strong>Imię:</strong> {animal.name}</p>
      <p><strong>Wiek:</strong> {animal.age}</p>
      <p><strong>Gatunek:</strong> {animal.species}</p>
      <p><strong>Rasa:</strong> {animal.breed}</p>
      <p><strong>Owner ID:</strong> {animal.ownerId}</p>

      <div style={{ marginTop: '1rem' }}>
        <Link to="/animals" style={{ marginRight: '1rem' }}>
          &larr; Powrót do listy
        </Link>
        <Link to={`/animals/${animal.id}/edit`}>
          Edytuj zwierzę
        </Link>
      </div>
    </div>
  );
};

export default AnimalDetailsPage;