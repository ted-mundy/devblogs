# devblogs

## Architecture

This is a monorepo, which contains everything neccessary to run an instance of the application.

The frontend uses Angular with server-side rendering enabled, to allow for better indexing from search engines.

The API will be written in ASP.NET, and will be a basic readonly API. We don't need people to sign up, or write comments.
The API will communicate to Celery workers via (Flower)[https://flower.readthedocs.io/en/latest/api.html#post--api-task-async-apply-(.+)] to trigger things such as manually adding posts

The Celery workers will parse the page content and insert the raw text into the database after any analysis is done (categorising the post, etc)
The Celery workers will be on a schedule (using Beat) to grab new posts from either RSS, or somewhere else.

The API will use a Postgres database to store everything.

Everything needs to be "component-based". Say for example we need to change DB to a cloud-based DB such as an Azure service. This should be *relatively* easy to do.

