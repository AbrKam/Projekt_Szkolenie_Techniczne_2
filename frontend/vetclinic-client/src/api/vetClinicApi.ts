import axios from 'axios'

const api = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
})

export interface AnimalDto {
  id: number
  name: string
  age: number
  species: string
  breed: string
  ownerId: number
}

export interface CreateAnimalDto {
  name: string
  age: number
  species: string
  breed: string
  ownerId: number
}

export const getAllAnimals = () =>
  api.get<AnimalDto[]>('/animals')

export const getAnimalById = (id: number) =>
  api.get<AnimalDto>(`/animals/${id}`)

export const createAnimal = (data: CreateAnimalDto) =>
  api.post<AnimalDto>('/animals', data)

export const updateAnimal = (id: number, data: CreateAnimalDto) =>
  api.put<AnimalDto>(`/animals/${id}`, data)

export const deleteAnimal = (id: number) =>
  api.delete<void>(`/animals/${id}`)

export interface AppointmentDto {
  id: number
  purpose: string
  description: string
  vetId: number
  animalId: number
  procedureIds: number[]
}

export interface CreateAppointmentDto {
  purpose: string
  description: string
  vetId: number
  animalId: number
  procedureIds: number[]
}

export const getAllAppointments = () =>
  api.get<AppointmentDto[]>('/appointments')

export const getAppointmentById = (id: number) =>
  api.get<AppointmentDto>(`/appointments/${id}`)

export const createAppointment = (data: CreateAppointmentDto) =>
  api.post<AppointmentDto>('/appointments', data)

export const updateAppointment = (id: number, data: CreateAppointmentDto) =>
  api.put<AppointmentDto>(`/appointments/${id}`, data)

export const deleteAppointment = (id: number) =>
  api.delete<void>(`/appointments/${id}`)