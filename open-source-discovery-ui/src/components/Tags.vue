<template>
  <div>
    <ul
      class="flex flex-row max-w-screen-sm md:flex-col md:w-48 overflow-x-scroll md:overflow-x-auto text-sm font-medium text-gray-900 bg-white border border-gray-200 rounded-lg"
    >
      <li
        v-for="tag in tags"
        class="w-full border-b border-gray-200 rounded-t-lg dark:border-gray-600"
      >
        <div class="flex items-center pl-3">
          <input
            disabled
            id="vue-checkbox"
            type="checkbox"
            value="{{ tag.name }}"
            checked
            class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500"
          />
          <label
            for="vue-checkbox"
            class="w-full py-3 ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
            >{{ tag.description }}</label
          >
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
import ProjectCard from "./shared/ProjectCard.vue";
import TagService from "@/services/tag";

export default {
  props: { id: String },
  components: { ProjectCard },
  data() {
    return {
      tags: [],
    };
  },
  created() {
    if (this.id != null) {
      TagService.getTagsByUserId(this.id).then((response) => {
        this.tags = response.data.tags;
      });
      return;
    }

    let local_tags_string = localStorage.getItem("local-tags");
    if (local_tags_string != null) {
      this.tags = JSON.parse(local_tags_string);
      return;
    }

    TagService.getTags().then((response) => {
      this.tags = response.data;
    });
  },
};
</script>
