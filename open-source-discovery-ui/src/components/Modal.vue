<script>
import tags from "../mock/tags.js";

export default {
  data() {
    return {
      listTags: [],
      selectedTags: [],
      tagClass:
        "flex items-center p-3 text-base font-bold text-gray-900 rounded-lg cursor-pointer group hover:shadow",
    };
  },
  methods: {
    selectTag(tag) {
      let selectedIndex = this.selectedTags.indexOf(tag.id);
      if (selectedIndex > -1) {
        let tagElement = document.getElementById("tag-" + tag.id);
        tagElement.className = this.tagClass + " bg-gray-50 hover:bg-gray-100";
        this.selectedTags.pop(selectedIndex);
      } else {
        this.selectedTags.push(tag.id);
        let tagElement = document.getElementById("tag-" + tag.id);
        tagElement.className = this.tagClass + " bg-blue-500 hover:bg-blue-200";
      }
    },
    closeModal() {
      let modal = document.getElementById("crypto-modal");
      modal.className += " hidden ";
    },
  },
  created() {
    this.listTags = tags;
  },
};
</script>
<template>
  <div
    id="crypto-modal"
    tabindex="-1"
    aria-hidden="true"
    class="flex justify-center items-center fixed top-0 left-0 right-0 z-50 w-full p-4 overflow-x-hidden overflow-y-auto md:inset-0 h-[calc(100%-1rem)] max-h-full"
  >
    <div
      class="relative w-full max-w-md max-h-full overflow-y-scroll shadow-md"
    >
      <div class="relative bg-white rounded-lg shadow dark:bg-gray-700">
        <button
          type="button"
          @click="closeModal()"
          class="absolute top-3 right-2.5 text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ml-auto inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white"
          data-modal-hide="crypto-modal"
        >
          <svg
            class="w-3 h-3"
            aria-hidden="true"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 14 14"
          >
            <path
              stroke="currentColor"
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"
            />
          </svg>
          <span class="sr-only">Fechar modal</span>
        </button>

        <div class="px-6 py-4 border-b rounded-t dark:border-gray-600">
          <h3
            class="text-base font-semibold text-gray-900 lg:text-xl dark:text-white"
          >
            Selecione seus interesses:
          </h3>
        </div>

        <div class="p-6 pt-2">
          <p class="text-sm font-normal text-gray-500 dark:text-gray-400">
            Estes interesses representam temas de projetos e organizações
            sociais.
          </p>

          <ul class="my-4 space-y-3">
            <li v-for="tag in listTags" @click="selectTag(tag)">
              <div
                :id="'tag-' + tag.id"
                class="flex items-center p-3 text-base font-bold text-gray-900 rounded-lg bg-gray-50 hover:bg-gray-100 group hover:shadow cursor-pointer"
              >
                <span class="flex-1 ml-3 whitespace-nowrap">
                  {{ tag.description }}
                </span>
              </div>
            </li>
          </ul>

          <div>
            <a
              class="inline-flex items-center text-xs font-normal text-gray-500 hover:underline dark:text-gray-400"
            >
              <svg
                class="w-3 h-3 mr-2"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 20 20"
              >
                <path
                  stroke="currentColor"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M7.529 7.988a2.502 2.502 0 0 1 5 .191A2.441 2.441 0 0 1 10 10.582V12m-.01 3.008H10M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"
                />
              </svg>
              Estes dados serão usados para vincular seu perfil a projetos!</a
            >
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
