import React, { useEffect, useState } from 'react';
import { useForm, SubmitHandler } from 'react-hook-form';
import { useNavigate, useParams } from 'react-router-dom';
import {
  getAppointmentById,
  createAppointment,
  updateAppointment,
  AppointmentDto,
  CreateAppointmentDto
} from '../api/vetClinicApi';

import { getAllAnimals, AnimalDto } from '../api/vetClinicApi';
import { getAllVeterinarians, VeterinarianDto } from '../api/vetClinicApi';
import { getAllProcedures, ProcedureDto } from '../api/vetClinicApi';

interface FormInputs {
  purpose: string;
  description: string;
  animalId: number;
  vetId: number;
  procedureIds: number[];
}

const AppointmentFormPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const isEdit = Boolean(id);
  const navigate = useNavigate();

  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const [animals, setAnimals] = useState<AnimalDto[]>([]);
  const [veterinarians, setVets] = useState<VeterinarianDto[]>([]);
  const [procedures, setProcedures] = useState<ProcedureDto[]>([]);

  const { register, handleSubmit, setValue, formState: { errors } } = useForm<FormInputs>();

  useEffect(() => {
    getAllAnimals().then(r => setAnimals(r.data));
    getAllVeterinarians().then(r => setVets(r.data));
    getAllProcedures().then(r => setProcedures(r.data));
  }, []);

  useEffect(() => {
    if (!isEdit) return;
    setLoading(true);
    getAppointmentById(Number(id))
      .then(r => {
        const a: AppointmentDto = r.data;
        setValue('purpose', a.purpose);
        setValue('description', a.description);
        setValue('animalId', a.animalId);
        setValue('vetId', a.vetId);
        setValue('procedureIds', a.procedureIds);
      })
      .catch(e => setError(e.message))
      .finally(() => setLoading(false));
  }, [id, isEdit, setValue]);

  const onSubmit: SubmitHandler<FormInputs> = data => {
    setLoading(true);
    setError(null);
    const dto: CreateAppointmentDto = {
      purpose: data.purpose,
      description: data.description,
      animalId: data.animalId,
      vetId: data.vetId,
      procedureIds: data.procedureIds
    };

    const action = isEdit
      ? updateAppointment(Number(id), dto)
      : createAppointment(dto);

    action
      .then(() => navigate('/appointments'))
      .catch(e => setError(e.message))
      .finally(() => setLoading(false));
  };

  return (
    <div style={{ padding: '1rem' }}>
      <h1>{isEdit ? 'Edytuj wizytę' : 'Dodaj nową wizytę'}</h1>

      {error && <p style={{ color: 'red' }}>Błąd: {error}</p>}
      {loading && <p>Ładowanie...</p>}

      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label>Cel wizyty:</label>
          <input {...register('purpose', { required: true })} />
          {errors.purpose && <span>Cel jest wymagany</span>}
        </div>

        <div>
          <label>Opis:</label>
          <textarea {...register('description')} />
        </div>

        <div>
          <label>Zwierzę:</label>
          <select {...register('animalId', { required: true })}>
            <option value="">-- wybierz --</option>
            {animals.map(a => (
              <option key={a.id} value={a.id}>{a.name} (ID: {a.id})</option>
            ))}
          </select>
          {errors.animalId && <span>Wybór zwierzęcia jest wymagany</span>}
        </div>

        <div>
          <label>Weterynarz:</label>
          <select {...register('vetId', { required: true })}>
            <option value="">-- wybierz --</option>
            {veterinarians.map(v => (
              <option key={v.id} value={v.id}>{v.firstName} {v.lastName}</option>
            ))}
          </select>
          {errors.vetId && <span>Wybór weterynarza jest wymagany</span>}
        </div>

        <div>
          <label>Procedury (Ctrl+klik, aby wybrać wiele):</label>
          <select multiple {...register('procedureIds')}> 
            {procedures.map(p => (
              <option key={p.id} value={p.id}>{p.procedureCode}</option>
            ))}
          </select>
        </div>

        <button type="submit" disabled={loading} style={{ marginTop: '1rem' }}>
          {isEdit ? 'Zapisz zmiany' : 'Dodaj wizytę'}
        </button>
      </form>
    </div>
  );
};

export default AppointmentFormPage;
