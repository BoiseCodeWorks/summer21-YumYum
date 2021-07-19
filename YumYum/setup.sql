CREATE TABLE Accounts(
  id VARCHAR(255) NOT NULL primary key comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  name varchar(255) NOT NULL comment 'Users given name',
  email varchar(255) NOT NULL comment 'Auth Email',
  picture varchar(255) NOT NULL comment 'Picture URL'
) default charset utf8 comment '';
SELECT
  *
FROM
  Accounts;
CREATE TABLE food_places(
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    name varchar(255) NOT NULL comment 'food place name',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account Id',
    FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE
  ) default charset utf8 comment '';
CREATE TABLE reviews(
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    body varchar(255) NOT NULL comment 'review body',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account Id',
    foodPlaceId int NOT NULL COMMENT 'FK: food_places id',
    FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE,
    FOREIGN KEY(foodPlaceId) REFERENCES food_places(id) ON DELETE CASCADE
  ) default charset utf8 comment '';
ALTER TABLE
    reviews
  ADD
    COLUMN rating int default 0;
  -- INSERT INTO
  --   food_places(name, creatorId)
  -- VALUES
  --   ("Papa Micks", "60b727ff650c4b5831dffc60");
  -- INSERT INTO
  --   food_places(name, creatorId)
  -- VALUES
  --   ("Mick's Mac", "60b727ff650c4b5831dffc60");
  -- INSERT INTO
  --   reviews(body, rating, creatorId, foodPlaceId)
  -- VALUES
  --   (
  --     "It was okay...",
  --     2,
  --     "60b727ff650c4b5831dffc60",
  --     1
  --   );
SELECT
  r.*,
  a.name AS username,
  a.picture,
  f.name
FROM
  reviews r
  JOIN Accounts a ON a.id = r.creatorId
  JOIN food_places f ON f.id = r.foodPlaceId;
SELECT
  r.*,
  a.*
FROM
  reviews r
  JOIN Accounts a ON a.id = r.creatorId;


ALTER TABLE reviews DROP COLUMN rating;

-- change the column to support large text input
ALTER TABLE
	reviews CHANGE body body longtext NOT NULL comment 'review body';

INSERT INTO reviews(body, creatorId, foodPlaceId)
VALUES("What is Lorem Ipsum?
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

Why do we use it?
It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).


Where does it come from?
Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.

Where can I get some?
There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", "60b727ff650c4b5831dffc60", 1);