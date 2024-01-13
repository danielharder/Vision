export interface BoardMember {
  userPK: string;
  role: string;
}

export interface TaskBoard {
  pk: string;
  name: string;
  description: string;
  boardMembers: BoardMember[];
}
