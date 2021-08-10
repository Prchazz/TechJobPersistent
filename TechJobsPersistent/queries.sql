--Part 1
Int Jobs.Id | LongTxt Jobs.Name | Int Jobs.EmployerId

--Part 2
SELECT Name FROM Employers WHERE Location - "St Louis City";

--Part 3

SELECT * FROM SKILLS
LEFT JOIN JobSkills ON Skills.Id = JobSkills.SkillId
WHERE JobSkills.JobId IS NOT NULL
ORDER BY name ASC;