<template>
  <Header></Header>
  <div class="container max-w-screen-xl mx-auto px-4">
    <nav class="flex items-center justify-between mb-10"></nav>

    <div class="text-center">
      <div class="flex justify-center mb-10">
        <img
          src="/images/companies/nasa.png"
          class="h-36"
          alt="Profile Image"
        />
      </div>

      <h6 class="font-medium text-gray-600 text-lg md:text-2xl uppercase mb-8">
        {{ user.name }}
      </h6>

      <h1
        class="font-normal text-gray-600 text-5xl md:text-6xl leading-none mb-8"
      >
        {{ user.office }}
      </h1>

      <p class="font-normal text-gray-600 text-md md:text-xl mb-16">
        {{ user.description }}
      </p>
    </div>

    <div class="flex flex-row justify-center mb-2" v-if="tags">
      <span
        v-for="tag in tags"
        class="flex flex-wrap pl-4 pr-4 py-2 m-1 justify-between items-center text-sm font-medium rounded-xl cursor-pointer bg-purple-500 text-gray-200 hover:bg-purple-600 hover:text-gray-100 dark:bg-gray-700 dark:text-gray-200 dark:hover:bg-gray-800 dark:hover:text-gray-100"
      >
        {{ tag.description }}
      </span>
    </div>

    <div class="flex">
      <ProjectMiniCard
        class="m-2"
        v-for="project in projects"
        :id="project.id"
        :name="project.title"
        :description="project.description"
      ></ProjectMiniCard>
    </div>
  </div>
</template>

<script>
import Header from "../components/shared/Header.vue";
import ProjectMiniCard from "../components/shared/ProjectMiniCard.vue";

export default {
  components: { Header, ProjectMiniCard },
  data() {
    return {
      user: {
        name: "Gustavo Antunes Voltolini",
        password: "test",
        description: "",
        office: "Backend Developer",
      },
      tags: [
        { id: 1, description: "Test1" },
        { id: 2, description: "Test2" },
      ],
      projects: [{ id: 2, title: "Titulo Test", description: "Test2" }],
    };
  },
};
</script>
