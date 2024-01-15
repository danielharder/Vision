import { Component, Input, OnInit } from '@angular/core';
import { Story } from '../interfaces/Story';
import { TaskBoardsService } from '../services/taskboards.service';

@Component({
  selector: 'app-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.css']
})
export class StoryComponent implements OnInit {
  @Input() laneId!: string;
  stories: Story[] = [];
  constructor(private taskBoardService: TaskBoardsService) { }

  ngOnInit(): void {
    if (this.laneId) {
      this.taskBoardService.getStoriesByLaneId(this.laneId).subscribe(
        (data: Story[]) => {
          this.stories = data;
          console.log("LanePK in Story Component: " + this.laneId);
        },
        (error) => {
          console.error('Error getting stories', error);
        }
      );
    }
  }
  addStory(): void {
    if (this.laneId == null) {
      console.error("Can't add story, LaneID is null or undefined.")
    }

    const newStoryData = {
      title: "New Story",
      description: "Default Description.",
      status: "Unassigned",
      laneID: this.laneId
    };

    this.taskBoardService.addStory(newStoryData).subscribe(
      (newStory: Story) => {
        this.stories.push(newStory);
      },
      (error) => {
        console.error('Error adding lane', error);
      }
    );
  }
  deleteStory(storyId: string): void {
    this.taskBoardService.deleteStory(storyId).subscribe(
      () => {
        this.stories = this.stories.filter(story => story.pk !== storyId);
      },
      (error) => {
        console.error('Error deleting story', error);
      }
    );
  }
}
