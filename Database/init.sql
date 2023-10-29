-- Get into correct database
USE Blog;
GO

-- Insert sample data into Authors table
INSERT INTO Authors (Name, Biography)
VALUES 
('Emily Johnson', 'Emily Johnson is a renowned poet and essayist, known for her vivid imagery and compelling prose.'),
('David Lee', 'David Lee is a science fiction author whose works explore futuristic worlds and advanced technologies.'),
('Sarah Green', 'Sarah Green is a travel writer who has journeyed across the globe, sharing her experiences through engaging narratives.'),
('Michael Brown', 'Michael Brown is a historian and author, specializing in medieval history and ancient civilizations.'),
('Rebecca White', 'Rebecca White is a novelist and short story writer, famous for her psychological thrillers and suspenseful plots.');

-- Insert sample data into Posts table
-- Posts by each author
DECLARE @AuthorId INT;

-- Posts by Emily Johnson
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'Emily Johnson');
INSERT INTO Posts (Title, Content, AuthorId)
VALUES 
('Whispers of the Wind', 'A collection of poems inspired by the beauty of nature.', @AuthorId),
('Reflections', 'An anthology of essays reflecting on life''s profound moments.', @AuthorId),
('The Silent River', 'A poetic journey along a mystical river.', @AuthorId),
('Moments in Time', 'A series of short stories about pivotal moments in people''s lives.', @AuthorId),
('Echoes of the Past', 'A poetic exploration of history and its echoes in the present.', @AuthorId);

-- Posts by David Lee
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'David Lee');
INSERT INTO Posts (Title, Content, AuthorId)
VALUES 
('Galactic Horizons', 'A novel about an interstellar journey to unknown planets.', @AuthorId),
('The Time Capsule', 'A story about a discovery that changes the course of humanity.', @AuthorId),
('Parallel Worlds', 'Exploring the concept of alternate realities through fiction.', @AuthorId),
('The Quantum Experiment', 'A thrilling tale of a scientific experiment gone wrong.', @AuthorId),
('Beyond the Stars', 'A collection of short stories set in distant galaxies.', @AuthorId);

-- Posts by Sarah Green
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'Sarah Green');
INSERT INTO Posts (Title, Content, AuthorId)
VALUES 
('Around the World', 'Sharing experiences from a journey around the globe.', @AuthorId),
('Hidden Gems', 'Discovering lesser-known destinations and their unique stories.', @AuthorId),
('Mountain Trails', 'Narratives from trekking some of the world''s highest peaks.', @AuthorId),
('Cultural Encounters', 'Stories of meaningful interactions with diverse cultures.', @AuthorId),
('Island Adventures', 'Adventures and experiences on remote islands.', @AuthorId);

-- Posts by Michael Brown
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'Michael Brown');
INSERT INTO Posts (Title, Content, AuthorId)
VALUES 
('Medieval Legends', 'Exploring the myths and legends of the medieval era.', @AuthorId),
('Ancient Civilizations', 'A deep dive into the history and culture of ancient societies.', @AuthorId),
('The Knights'' Code', 'An analysis of the chivalric code and its impact on medieval society.', @AuthorId),
('Roman Empire', 'Insights into the rise and fall of the Roman Empire.', @AuthorId),
('Viking Voyages', 'Recounting the expeditions and conquests of the Vikings.', @AuthorId);

-- Posts by Rebecca White
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'Rebecca White');
INSERT INTO Posts (Title, Content, AuthorId)
VALUES 
('Shadows in the Dark', 'A psychological thriller about secrets hidden in plain sight.', @AuthorId),
('The Unseen', 'A novel exploring the concept of invisible forces influencing our lives.', @AuthorId),
('Mind Games', 'A suspenseful story of manipulation and deceit.', @AuthorId),
('The Forgotten', 'A tale about the consequences of forgotten memories resurfacing.', @AuthorId),
('Web of Lies', 'A gripping story unraveling a complex web of lies and betrayal.', @AuthorId);
