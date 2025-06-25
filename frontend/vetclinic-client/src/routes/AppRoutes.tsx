import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import AnimalsListPage from '../pages/AnimalsListPage';
import AnimalFormPage from '../pages/AnimalsFormPage';
import AnimalDetailsPage from '../pages/AnimalsDetailsPage';
import AppointmentsListPage from '../pages/AppointmentListPage';
import AppointmentFormPage  from '../pages/AppointmentFormPage';
import NotFoundPage from '../pages/NotFoundPage';

const AppRoutes: React.FC = () => (
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<Navigate to="/animals" replace />} />

      <Route path="/animals" element={<AnimalsListPage />} />
      <Route path="/animals/:id" element={<AnimalDetailsPage />} />
      <Route path="/animals/new" element={<AnimalFormPage />} />
      <Route path="/animals/:id/edit" element={<AnimalFormPage />} />
      <Route path="/appointments" element={<AppointmentsListPage />} />
      <Route path="/appointments/new" element={<AppointmentFormPage />} />

      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  </BrowserRouter>
);

export default AppRoutes;
