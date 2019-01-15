import { ClassroomModel } from './classroom-model';

export class ExamModel {
    id: number;
    title: string;
    description: string;
    date: string;
    startHour: string;
    finishHour: string;
    courseId: number;
    professorId: number;
    classroomsList: ClassroomModel[];

    constructor() {}
  }
  