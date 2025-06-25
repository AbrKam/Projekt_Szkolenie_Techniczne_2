import React, { useEffect, useState } from 'react';
import { useForm, SubmitHandler } from 'react-hook-form';
import { useNavigate, useParams } from 'react-router-dom';
import {
  getAnimalById,
  createAnimal,
  updateAnimal,
  AnimalDto,
  CreateAnimalDto,
} from '../api/vetClinicApi';
import { AnimalSpecies } from '../api/types';

interface FormInputs {
  ownerId: number;
  name: string;
  age: number;
  species: AnimalSpecies;
  breed: string;
}

const AnimalFormPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const isEdit = Boolean(id);
  const navigate = useNavigate();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const { register, handleSubmit, setValue, formState: { errors } } = useForm<FormInputs>();

  useEffect(() => {
    if (!isEdit) return;
    setLoading(true);
    getAnimalById(Number(id))
      .then(res => {
        const a: AnimalDto = res.data;
        setValue('ownerId', a.ownerId);
        setValue('name', a.name);
        setValue('age', a.age);
        setValue('species', a.species as AnimalSpecies);
        setValue('breed', a.breed);
      })
      .catch(err => setError(err.message))
      .finally(() => setLoading(false));
  }, [id, isEdit, setValue]);

  const onSubmit: SubmitHandler<FormInputs> = data => {
    setLoading(true);
    const dto: CreateAnimalDto = {
      ownerId: data.ownerId,
      name: data.name,
      age: data.age,
      species: data.species,
      breed: data.breed
    };

    const action = isEdit
      ? updateAnimal(Number(id), dto)
      : createAnimal(dto);

    action
      .then(() => navigate('/animals'))
      .catch(err => setError(err.message))
      .finally(() => setLoading(false));
  };

  return (
    <div style={{ padding: '1rem' }}>
      <h1>{isEdit ? 'Edytuj zwierzę' : 'Dodaj nowe zwierzę'}</h1>

      {error && <p style={{ color: 'red' }}>Błąd: {error}</p>}
      {loading && <p>Ładowanie...</p>}

      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label>Owner ID:</label>
          <input type="number" {...register('ownerId', { required: true, min: 1 })} />
          {errors.ownerId && <span>OwnerId jest wymagane</span>}
        </div>
        <div>
          <label>Imię:</label>
          <input {...register('name', { required: true })} />
          {errors.name && <span>Imię jest wymagane</span>}
        </div>
        <div>
          <label>Wiek:</label>
          <input type="number" {...register('age', { required: true, min: 0 })} />
          {errors.age && <span>Wiek musi być nieujemny</span>}
        </div>
        <div>
          <label>Gatunek:</label>
          <select {...register('species', { required: true })}>
            {Object.values(AnimalSpecies).map(species => (
              <option key={species} value={species}>{species}</option>
            ))}
          </select>
          {errors.species && <span>Gatunek jest wymagany</span>}
        </div>
        <div>
          <label>Rasa:</label>
          <input {...register('breed', { required: true })} />
          {errors.breed && <span>Rasa jest wymagana</span>}
        </div>

        <button type="submit" disabled={loading} style={{ marginTop: '1rem' }}>
          {isEdit ? 'Zapisz zmiany' : 'Dodaj zwierzę'}
        </button>
      </form>
    </div>
  );
};

export default AnimalFormPage;
