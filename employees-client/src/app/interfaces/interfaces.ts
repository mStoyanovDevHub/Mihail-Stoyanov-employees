export interface PairProjectDetail {
  projectId: number;
  daysWorked: number;
}

export interface PairResultDto {
  empId1: number;
  empId2: number;
  totalDays: number;
  projects: PairProjectDetail[];
}

export interface ProcessingResult {
  topPair: PairResultDto;
  allPairs: PairResultDto[];
}
