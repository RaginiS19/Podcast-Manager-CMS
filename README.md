
# Podcast Manager CMS

## 1. What It Is

A clean, no-fuss **Content Management System** that helps podcasters keep track of their:
- Shows
- Episodes 
- Guest collaborations

All in one organized platform.

## 2. Who It's For

🎙️ **Independent podcasters** (solo creators or small teams)  
❤️ **Passionate hobbyists** who want to focus on content, not management  
🚀 **Emerging creators** needing basic scheduling and tracking tools  

## 3. Key Features

### Podcast & Episode Management
- Add/edit show details (title, description)  
- Schedule and track episode releases  
- Mark episode status (Draft/Published/Archived)

### Guest Tracking
- Maintain a guest directory with contact info  
- Visualize guest appearances across episodes  
- Track frequent collaborators

### Admin Dashboard
- Single-view management of all content  
- Simple CRUD (Create, Read, Update, Delete) operations  
- Quick search and filtering  

## 4. Technical Implementation

### Built With
- ASP.NET Core 6.0
- Entity Framework Core (Code First)
- MVC Architecture
- SQL Server Database

### Database Schema

### 🗃️ Database Structure
- **1-to-Many Relationship**: Podcasts → Episodes
- **Many-to-Many Relationship**: Episodes ↔ Guests
  
    PODCAST {
        int Id PK
        string Title
        string Description
        string CoverArtUrl
    }
    EPISODE {
        int Id PK
        string Title
        datetime PublishDate
        int PodcastId FK
    }
    GUEST {
        int Id PK
        string Name
        string Bio
    }
    EPISODE_GUEST {
        int EpisodeId FK
        int GuestId FK
    }
